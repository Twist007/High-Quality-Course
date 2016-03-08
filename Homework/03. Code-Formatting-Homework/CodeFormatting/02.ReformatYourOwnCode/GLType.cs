namespace _02.ReformatYourOwnCode
{
    using System;
    using System.Collections;
    using System.Text;

    public partial class GlType
    {
        private static Hashtable typeTable;
        private readonly string typeName;
        private readonly int stars;

        public GlType(string glType, int stars)
        {
            this.stars = stars;
            this.typeName = GetCsType(glType);
        }

        /** return the C# representation of a type for a given level.
        * @param isReturn tell wether or not it is a return argument as
        * the representation are different
        * @param codeFriendly to generate a compilable name for CFunction
        * name. */
        public int Level
        {
            get
            {
                if (this.stars == 0)
                {
                    return 1;
                }

                if (this.stars == 1 && this.typeName == "void")
                {
                    return 10;
                }

                return 3;
            }
        }

        public bool IsVoid
        {
            get
            {
                return this.stars == 0 && this.typeName == "void";
            }
        }

        public bool IsPointer
        {
            get
            {
                return this.stars > 0;
            }
        }

        public int Size
        {
            get
            {
                switch (this.typeName)
                {
                    case "void":
                        return 0;
                    case "byte":
                    case "sbyte":
                        return 1;
                    case "short":
                    case "ushort":
                        return 2;
                    case "int":
                    case "uint":
                        return 4;
                    case "float":
                        return 4;
                    case "double":
                        return 8;
                    default:
                        throw new ArgumentException("unknown base type");
                }
            }
        }

        /** return the C# representation of a type for a given level.
      * @param isReturn tell wether or not it is a return argument as
      * the representation are different
      * @param codeFriendly to generate a compilable name for CFunction
      * name. */
        public string ToString(int level, bool isReturn, bool codeFriendly)
        {
            if (this.stars == 0)
            {
                return this.typeName;
            }

            // C - name
            if (level == 0)
            {
                return this.typeName + this.StarString(codeFriendly ? 'P' : '*');
            }

            if (this.stars > 1 || isReturn || level == 1)
            {
                return "IntPtr";
            }

            if (this.typeName == "void")
            {
                switch (level)
                {
                    case 2:
                        return "byte[]";
                    case 3:
                        return "sbyte[]";
                    case 4:
                        return "short[]";
                    case 5:
                        return "ushort[]";
                    case 6:
                        return "int[]";
                    case 7:
                        return "uint[]";
                    case 8:
                        return "float[]";
                    case 9:
                        return "double[]";
                }
            }

            return this.typeName + "[]";
        }

        public static string GetCsType(string glType)
        {
            if (typeTable == null)
            {
                typeTable = CreateTypeTable();
            }

            string ret = (string)typeTable[glType];
            if (ret == null)
            {
                Console.Error.WriteLine("warning: unknown type \"" + glType + "\" use as is.");
                typeTable[glType] = glType;
                ret = glType;
            }

            return ret;
        }

        private static Hashtable CreateTypeTable()
        {
            Hashtable ret = new Hashtable();
            ret["void"] = "void";
            ret["GLvoid"] = "void";
            ret["GLenum"] = "uint";
            ret["GLbyte"] = "byte";
            ret["GLshort"] = "short";
            ret["GLint"] = "int";
            ret["GLsizei"] = "int";
            ret["GLubyte"] = "byte";
            ret["GLuint"] = "uint";
            ret["GLfloat"] = "float";
            ret["GLushort"] = "ushort";
            ret["GLclampf"] = "float";
            ret["GLdouble"] = "double";
            ret["GLclampd"] = "double";
            ret["GLboolean"] = "byte";
            ret["GLbitfield"] = "uint";

            return ret;
        }

        private string StarString(char c)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.stars; i++)
            {
                sb.Append(c);
            }

            return sb.ToString();
        }
    }
}