using antlr;
using   antlr.collections;
      using System;
using System.Collections;
using System.Globalization;
using System.IO         ;
using System.Text;

public class GLType
{
 public string typeName;               public int stars;

	public                   GLType(string GLType     )
	{		typeName = GetCSType       (GLType);
                                 }

	/** return the generation specific level of this type.
	 *  roughly equal to the number of polymorphic type
	 * it could have. <br>
	 * <b>Note</b> a return type has a maximum of 3 level, anyway. */
           public int Level
    {
		get {
if(stars  ==  0)	return 1; if(stars==1 && typeName == "void") return 10;
		return 3;
		}
	}

	public
bool
IsVoid
{ get
{
return
 stars==
 0
&&
 typeName == "void"; } }

	/** return the C# representation of a type for a given level.
	 * @param isReturn tell wether or not it is a return argument as
	 * the representation are different
	 * @param codeFriendly to generate a compilable name for CFunction
	 * name. */
	public string ToString(int level, bool isReturn, bool codeFriendly)
	{
		if(stars==0)
			return typeName;
		if(level==0) // C - name
			return typeName+StarString     (codeFriendly ? 'P' : '*');
		if(stars>1 || isReturn || level==1)
			return "IntPtr";
		if(typeName=="void") switch(level) {
				case 2: return "byte[]";  case 3: return "sbyte[]";
				case 4: return "short[]"; case 5: return "ushort[]";
				case 6: return "int[]";		case 7: return "uint[]";
				case        8:
                                return "float[]";	case 9: return "double[]";
			}
		return typeName+"[]";
	}
	string StarString(char c)
	{
		StringBuilder sb = new StringBuilder();
		for(int i=0; i<stars; i++)
			sb.Append(c);
		return sb.ToString();
	}
	public bool IsPointer { get { return stars>0; } }
	public int Size
	{
		get {
			switch(typeName) {
				case "void":
					return 0;
		case "byte":
				case "sbyte":		return 1;
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
	static Hashtable typeTable;
	public static string GetCSType(string GLType)
	{
		if(typeTable == null)	typeTable = createTypeTable();
		string ret = (string)
                 typeTable[GLType];
		if(ret
                 ==
                  null) {
			Console.Error.WriteLine("warning: unknown type \""+GLType+"\" use as is.");
			typeTable[GLType] = GLType;
			ret = GLType;
		}
		return ret;
	}
	static Hashtable createTypeTable()
{
	Hashtable ret = new Hashtable();
		ret  ["void"] = "void";
ret[  "GLvoid"] = "void";
	ret["GLenum"  ] = "uint";
		ret["GLbyte"] = "byte";	ret["GLshort"] = "short";ret["GLint"] = "int";
ret["GLsizei"] = "int";	ret["GLubyte"] = "byte"; ret["GLuint"] = "uint"; ret["GLfloat"] = "float";
		ret["GLushort"] = "ushort";
		ret["GLclampf"] = "float";
		ret["GLdouble"] = "double";


		ret["GLclampd"] = "double";
		ret["GLboolean"] = "byte";
		ret["GLbitfield"] = "uint";
		return ret;
	}
}