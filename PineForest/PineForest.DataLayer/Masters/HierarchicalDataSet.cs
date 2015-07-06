using System;
using System.Data;
using System.Web.UI;
using System.Collections;

namespace PineForest.DataLayer
{
  /// <summary>
  /// A class that translates a DataSet into IHierarchicalDataSource that can be used to bind Hierarchical data to a TreeView
  /// </summary>
  public class HierarchicalDataSet : IHierarchicalDataSource
  {
    #region Readonly

    /// <summary>
    /// The DataView reference that the class is pointing to
    /// </summary>
    readonly DataView dataView;

    /// <summary>
    /// The name of the primary key column
    /// </summary>
    readonly string idColumnName;

    /// <summary>
    /// The name of the parent foreign key column
    /// </summary>
    readonly string parentIdColumnName;

    /// <summary>
    /// evaluated once the constructor is called, true if the primary keys are strings
    /// </summary>
    readonly bool columnIsString;

    /// <summary>
    /// evaluated once the constructor is called, true if the primary keys are strings
    /// </summary>
    readonly object rootParentColumnValue;

    #endregion

    #region Public Methods

    /// <summary>
    /// The constructor of the class
    /// </summary>
    /// <param name="dataSet">The dataset that contains the data, the first table's view will be taken</param>
    /// <param name="idColumnName">The Primary key column name</param>
    /// <param name="parentIdColumnName">The Parent Primary key column name that identifies the Parent-Child relationship</param>
    /// <param name="rootParentColumnValue">By Default, the tree will load from the root, if you want to load a subtree, specify the value of the toplevel record here</param>
    public HierarchicalDataSet(DataSet dataSet, string idColumnName, string parentIdColumnName, object rootParentColumnValue)
    {
      dataView = dataSet.Tables[0].DefaultView;
      this.idColumnName = idColumnName;
      this.parentIdColumnName = parentIdColumnName;
      this.rootParentColumnValue = rootParentColumnValue;

      if (dataSet.Tables[0].Columns[idColumnName].DataType != dataSet.Tables[0].Columns[parentIdColumnName].DataType)
        throw new Exception("The two column names passed should be of the same type");

      columnIsString = dataSet.Tables[0].Columns[idColumnName].DataType == typeof(string);
      System.Diagnostics.Debug.Assert(
      dataSet.Tables[0].Columns[idColumnName].DataType ==
      dataSet.Tables[0].Columns[parentIdColumnName].DataType,
      "The Column of the ID and the Column of the ParentID should be of the same type");
    }

    /// <summary>
    /// The constructor of the class
    /// </summary>
    /// <param name="dataSet">The dataset that contains the data, the first table's view will be taken</param>
    /// <param name="idColumnName">The Primary key column name</param>
    /// <param name="parentIdColumnName">The Parent Primary key column name that identifies the Parent-Child relationship</param>
    public HierarchicalDataSet(DataSet dataSet, string idColumnName, string parentIdColumnName)
    {
      dataView = dataSet.Tables[0].DefaultView;
      this.idColumnName = idColumnName;
      this.parentIdColumnName = parentIdColumnName;
      rootParentColumnValue = null;

      if (dataSet.Tables[0].Columns[idColumnName].DataType != dataSet.Tables[0].Columns[parentIdColumnName].DataType)
        throw new Exception("The two column names passed should be of the same type");

      columnIsString = dataSet.Tables[0].Columns[idColumnName].DataType == typeof(string);
      System.Diagnostics.Debug.Assert(
      dataSet.Tables[0].Columns[idColumnName].DataType ==
      dataSet.Tables[0].Columns[parentIdColumnName].DataType,
      "The Column of the ID and the Column of the ParentID should be of the same type");
    }

    /// <summary>
    /// The constructor of the class
    /// </summary>
    /// <param name="dataView">The dataView that contains the data</param>
    /// <param name="idColumnName">The Primary key column name</param>
    /// <param name="parentIdColumnName">The Parent Primary key column name that identifies the Parent-Child relationship</param>
    /// <param name="rootParentColumnValue">By Default, the tree will load from the root, if you want to load a subtree, specify the value of the toplevel record here</param>
    public HierarchicalDataSet(DataView dataView, string idColumnName, string parentIdColumnName, object rootParentColumnValue)
    {
      this.dataView = dataView;
      this.idColumnName = idColumnName;
      this.parentIdColumnName = parentIdColumnName;
      this.rootParentColumnValue = rootParentColumnValue;

      if (dataView.Table.Columns[idColumnName].DataType != dataView.Table.Columns[parentIdColumnName].DataType)
        throw new Exception("The two column names passed should be of the same type");

      columnIsString = dataView.Table.Columns[idColumnName].DataType == typeof(string);
    }

    /// <summary>
    /// The constructor of the class
    /// </summary>
    /// <param name="dataView">The dataView that contains the data</param>
    /// <param name="idColumnName">The Primary key column name</param>
    /// <param name="parentIdColumnName">The Parent Primary key column name that identifies the Parent-Child relationship</param>
    public HierarchicalDataSet(DataView dataView, string idColumnName, string parentIdColumnName)
    {
      this.dataView = dataView;
      this.idColumnName = idColumnName;
      this.parentIdColumnName = parentIdColumnName;
      rootParentColumnValue = null;

      if (dataView.Table.Columns[idColumnName].DataType != dataView.Table.Columns[parentIdColumnName].DataType)
        throw new Exception("The two column names passed should be of the same type");

      columnIsString = dataView.Table.Columns[idColumnName].DataType == typeof(string);
    }

    public event EventHandler DataSourceChanged; // never used here

    public HierarchicalDataSourceView GetHierarchicalView(string viewPath)
    {
      return new DataSourceView(this, viewPath);
    }

    #endregion

    #region supporting methods

    /// <summary>
    /// Gets the parent row, given a row
    /// </summary>
    /// <param name="row"></param>
    /// <returns></returns>
    DataRowView GetParentRow(DataRowView row)
    {
      dataView.RowFilter = GetFilter(idColumnName, row[parentIdColumnName].ToString());
      DataRowView parentRow = dataView[0];
      dataView.RowFilter = "";
      return parentRow;
    }

    /// <summary>
    /// Prepares the filter based on the column names and type
    /// </summary>
    /// <param name="columnName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    private string GetFilter(string columnName, string value)
    {
      if (columnIsString)
        return String.Format("[{0}] = '{1}'", columnName, value.Replace("'", "''"));
      else
        return String.Format("[{0}] = {1}", columnName, value);
    }

    /// <summary>
    /// GetChildrenViewPath
    /// </summary>
    /// <param name="viewPath"></param>
    /// <param name="row"></param>
    /// <returns></returns>
    string GetChildrenViewPath(string viewPath, DataRowView row)
    {
      return viewPath + "\\" + row[idColumnName].ToString();
    }

    /// <summary>
    /// HasChildren
    /// </summary>
    /// <param name="row"></param>
    /// <returns></returns>
    bool HasChildren(DataRowView row)
    {
      dataView.RowFilter = GetFilter(parentIdColumnName, row[idColumnName].ToString());
      bool hasChildren = dataView.Count > 0;
      dataView.RowFilter = "";
      return hasChildren;
    }

    /// <summary>
    /// GetParentViewPath
    /// </summary>
    /// <param name="viewPath"></param>
    /// <returns></returns>
    string GetParentViewPath(string viewPath)
    {
      return viewPath.Substring(0, viewPath.LastIndexOf("\\"));
    }

    #endregion

    #region private classes that implement further interfaces

    class DataSourceView : HierarchicalDataSourceView
    {
      readonly HierarchicalDataSet hDataSet;
      readonly string viewPath;

      public DataSourceView(HierarchicalDataSet hDataSet, string viewPath)
      {
        this.hDataSet = hDataSet;
        this.viewPath = viewPath;
      }

      public override IHierarchicalEnumerable Select()
      {
        return new HierarchicalEnumerable(hDataSet, viewPath);
      }
    }

    class HierarchicalEnumerable : IHierarchicalEnumerable
    {
      readonly HierarchicalDataSet hDataSet;
      readonly string viewPath;

      public HierarchicalEnumerable(HierarchicalDataSet hDataSet, string viewPath)
      {
        this.hDataSet = hDataSet;
        this.viewPath = viewPath;
      }

      public IHierarchyData GetHierarchyData(object enumeratedItem)
      {
        DataRowView row = (DataRowView)enumeratedItem;
        return new HierarchyData(hDataSet, viewPath, row);
      }

      public IEnumerator GetEnumerator()
      {
        if (viewPath == "")
        {
          if (hDataSet.rootParentColumnValue != null)
            hDataSet.dataView.RowFilter = hDataSet.GetFilter(hDataSet.parentIdColumnName, hDataSet.rootParentColumnValue.ToString());
          else
          {
            if (hDataSet.columnIsString)
              hDataSet.dataView.RowFilter = String.Format("[{0}] is null or [{0}] = ''",
              hDataSet.parentIdColumnName);
            else
              hDataSet.dataView.RowFilter = String.Format("[{0}] is null or [{0}] = 0",
              hDataSet.parentIdColumnName);
          }
        }
        else
        {
          string lastID = viewPath.Substring(viewPath.LastIndexOf("\\") + 1);
          hDataSet.dataView.RowFilter = hDataSet.GetFilter(hDataSet.parentIdColumnName, lastID);
        }

        IEnumerator i = hDataSet.dataView.ToTable().DefaultView.GetEnumerator();
        hDataSet.dataView.RowFilter = "";

        return i;
      }
    }

    class HierarchyData : IHierarchyData
    {
      readonly HierarchicalDataSet hDataSet;
      readonly DataRowView row;
      readonly string viewPath;

      public HierarchyData(HierarchicalDataSet hDataSet, string viewPath, DataRowView row)
      {
        this.hDataSet = hDataSet;
        this.viewPath = viewPath;
        this.row = row;
      }

      public IHierarchicalEnumerable GetChildren()
      {
        return new HierarchicalEnumerable(hDataSet, hDataSet.GetChildrenViewPath(viewPath, row));
      }

      public IHierarchyData GetParent()
      {
        return new HierarchyData(hDataSet, hDataSet.GetParentViewPath(viewPath), hDataSet.GetParentRow(row));
      }

      public bool HasChildren
      {
        get
        {
          return hDataSet.HasChildren(row);
        }
      }

      public object Item
      {
        get
        {
          return row;
        }
      }

      public string Path
      {
        get
        {
          return viewPath;
        }
      }

      public string Type
      {
        get
        {
          return typeof(DataRowView).ToString();
        }
      }
    }

    #endregion
  }
}

