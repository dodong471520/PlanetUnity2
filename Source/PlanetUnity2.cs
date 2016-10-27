

using UnityEngine;


//
// Autogenerated by gaxb ( https://github.com/SmallPlanet/gaxb )
//

using System.Xml;
using System.Text;
using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Collections;
using TB;

interface IPlanetUnity2
{
	void gaxb_load(TBXMLElement element, object _parent, Hashtable args);
	void gaxb_appendXML(StringBuilder sb);
}

public class PlanetUnity2 {
	public int baseRenderQueue = 0;

	public enum GridLayoutChildAlignment {
		upperLeft,
		upperCenter,
		upperRight,
		middleLeft,
		middleCenter,
		middleRight,
		lowerLeft,
		lowerCenter,
		lowerRight,
	};

	public const string USERSTRINGINPUT = "UserStringInput";
	public const string USERCHARINPUT = "UserCharInput";
	public const string USERINPUTCANCELLED = "UserInputCancelled";
	public const string BUTTONTOUCHDOWN = "ButtonTouchDown";
	public const string BUTTONTOUCHUP = "ButtonTouchUp";
	public const string EVENTWITHUNREGISTEREDCOLLIDER = "EventWithUnregisteredCollider";
	public const string EVENTWITHNOCOLLIDER = "EventWithNoCollider";
	public const string EDITORFILEDIDCHANGE = "EditorFileDidChange";

	public enum CanvasRenderMode {
		ScreenSpaceOverlay,
		ScreenSpaceCamera,
		WorldSpace,
	};

	public enum ParticleEmitMode {
		SystemNone,
		SystemScaled,
		Edge,
		Fill,
		Center,
		Image,
	};

	public enum TextOverflowVertical {
		truncate,
		overflow,
	};

	public enum AspectFitMode {
		None,
		WidthControlsHeight,
		HeightControlsWidth,
		FitInParent,
		EnvelopeParent,
	};

	public enum SliderDirection {
		LeftToRight,
		RightToLeft,
		BottomToTop,
		TopToBottom,
	};

	public enum TextOverflowHorizontal {
		wrap,
		overflow,
	};

	public enum FontStyle {
		normal,
		bold,
		italic,
		boldAndItalic,
	};

	public enum TextAlignment {
		upperLeft,
		upperCenter,
		upperRight,
		middleLeft,
		middleCenter,
		middleRight,
		lowerLeft,
		lowerCenter,
		lowerRight,
	};

	public enum ImageType {
		simple,
		filled,
		sliced,
		tiled,
		aspectFilled,
	};

	public enum InputFieldContentType {
		standard,
		autocorrected,
		integer,
		number,
		alphanumeric,
		name,
		email,
		password,
		pin,
		custom,
	};

	public enum GridTableHeuristic {
		RectBestShortSideFit,
		RectBestLongSideFit,
		RectBestAreaFit,
		RectBottomLeftRule,
		RectContactPointRule,
	};

	public enum GridLayoutStartCorner {
		upperLeft,
		upperRight,
		lowerLeft,
		lowerRight,
	};

	public enum InputFieldLineType {
		single,
		multiSubmit,
		multiNewline,
	};

	public enum GridLayoutStartAxis {
		horizontal,
		vertical,
	};



	static public string ConvertClassName(string xmlNamespace, string name)
	{
		return Regex.Replace(xmlNamespace, "[^A-Z]", "")+name;
	}

	static public T clone<T>(T root) {
		return (T)loadXML( System.Text.Encoding.UTF8.GetBytes (writeXML (root)), null, null);
	}

	static public string writeXML(object root) {
		StringBuilder sb = new StringBuilder ();
		MethodInfo mInfo = root.GetType().GetMethod("gaxb_appendXML");
		if(mInfo != null) {
			mInfo.Invoke (root, new[] { sb });
		}
		return sb.ToString();
	}

	static public object loadXML(byte[] xmlBytes, object parentObject, Hashtable args, Action<object,object,TBXMLElement> customBlock)
	{
		object rootEntity = parentObject;
		object returnEntity = null;

		Stack<string> xmlNamespaces = new Stack<string> ();

		new TBXMLReader (xmlBytes, (element) => {

			string elementName = element.GetName ();

      string localXmlNamespace = element.GetAttribute ("xmlns");
			if (localXmlNamespace != null) {
				xmlNamespaces.Push (localXmlNamespace);
			} else if (xmlNamespaces.Count > 0) {
				localXmlNamespace = xmlNamespaces.Peek ();
			} else {
				localXmlNamespace = "";
			}

			try {
				Type entityClass = Type.GetType (ConvertClassName (localXmlNamespace, elementName), true);
				PUObject entityObject = (PUObject)(Activator.CreateInstance (entityClass));

				if (customBlock == null) {
					entityObject.gaxb_load (element, rootEntity, args);
					entityObject.gaxb_init ();
					entityObject.gaxb_final (element, rootEntity, args);
				} else {
					customBlock (entityObject, rootEntity, element);
				}

				rootEntity = entityObject;

				if (returnEntity == null) {
					returnEntity = entityObject;
				}
			} catch (TypeLoadException) {
				// If we get here its not a valid PU class, throw it away
			}
		}, (element) => {
			try {
				string elementName = element.GetName ();
				string localXmlNamespace = xmlNamespaces.Count > 0 ? xmlNamespaces.Peek () : "";
				if (element.GetAttribute ("xmlns") != null) {
					xmlNamespaces.Pop ();
				}

				// is this the closing end of a valid PU object?
				Type entityClass = Type.GetType (ConvertClassName (localXmlNamespace, elementName), true);

				if (entityClass != null) {
					if (customBlock == null) {
						PUObject entityObject = rootEntity as PUObject;
						entityObject.gaxb_complete ();
						entityObject.gaxb_private_complete ();
					}

					object parent = rootEntity.GetType ().GetField ("parent").GetValue (rootEntity);
					if (parent != null) {
						rootEntity = parent;
					}
				}
			} catch (TypeLoadException) {
			}
		});

		return returnEntity;
	}

	static public object loadXML(byte[] xmlBytes, object parentObject, Hashtable args)
	{
		return loadXML(xmlBytes, parentObject, args, null);
	}
}
