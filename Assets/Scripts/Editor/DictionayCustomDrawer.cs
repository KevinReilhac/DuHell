using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(BaseCard.CustomPropertiesDict))]
public class AnyDictionaryDrawer : SerializableDictionaryPropertyDrawer { }
