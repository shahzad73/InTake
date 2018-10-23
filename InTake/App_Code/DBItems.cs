using System;
using System.Collections.Generic;

using System.Web;

/// <summary>
/// Summary description for DBItems
/// </summary>
public class DBItem
{
    public string FieldName;
    public string FieldType;
    public string DBField;
    public string DBFieldType;
    public bool IsPrimaryKey;

    public string _ErrorMessage = "";
    public string ErrorMessage
    {
        get { return _ErrorMessage; }
        set { _ErrorMessage = value; }
    }


    public bool _IsMandatory = false;
    public bool IsMandatory
    {
        get { return _IsMandatory; }
        set { _IsMandatory = value; }
    }





    //These columns define the table bound properties.   Name of the table    Id column of the table     and text field bound column
    public string _TableBound = "";
    public string TableBound
    {
        get { return _TableBound; }
        set { _TableBound = value; }
    }


    public string _TableBoundIDColumn = "";
    public string TableBoundIDColumn
    {
        get { return _TableBoundIDColumn; }
        set { _TableBoundIDColumn = value; }
    }


    public string _TableBoundTextFieldColumn = "";
    public string TableBoundTextFieldColumn
    {
        get { return _TableBoundTextFieldColumn; }
        set { _TableBoundTextFieldColumn = value; }
    }





	public DBItem(string name, string type, string dbfield, string dbfieldtype, bool isprimary)
	{
        FieldName = name;
        FieldType = type;
        DBField = dbfield;
        DBFieldType = dbfieldtype;
        IsPrimaryKey = isprimary;
	}


}

