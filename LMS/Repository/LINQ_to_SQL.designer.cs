﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Repository
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="LMS_Vishnu_Prakash")]
	public partial class LINQ_to_SQLDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void Inserttbl_BookModel(tbl_BookModel instance);
    partial void Updatetbl_BookModel(tbl_BookModel instance);
    partial void Deletetbl_BookModel(tbl_BookModel instance);
    partial void Inserttbl_UserModel(tbl_UserModel instance);
    partial void Updatetbl_UserModel(tbl_UserModel instance);
    partial void Deletetbl_UserModel(tbl_UserModel instance);
    #endregion
		
		public LINQ_to_SQLDataContext() : 
				base(global::Repository.Properties.Settings.Default.LMS_Vishnu_PrakashConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public LINQ_to_SQLDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LINQ_to_SQLDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LINQ_to_SQLDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LINQ_to_SQLDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<tbl_BookHistoryModel> tbl_BookHistoryModels
		{
			get
			{
				return this.GetTable<tbl_BookHistoryModel>();
			}
		}
		
		public System.Data.Linq.Table<tbl_BookModel> tbl_BookModels
		{
			get
			{
				return this.GetTable<tbl_BookModel>();
			}
		}
		
		public System.Data.Linq.Table<tbl_UserModel> tbl_UserModels
		{
			get
			{
				return this.GetTable<tbl_UserModel>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tbl_BookHistoryModel")]
	public partial class tbl_BookHistoryModel
	{
		
		private int _BookID;
		
		private int _UserID;
		
		private System.DateTime _OperationPerformedAt;
		
		private System.DateTime _ReturnedAt;
		
		private string _Remarks;
		
		private string _PerformedByID;
		
		public tbl_BookHistoryModel()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BookID", DbType="Int NOT NULL")]
		public int BookID
		{
			get
			{
				return this._BookID;
			}
			set
			{
				if ((this._BookID != value))
				{
					this._BookID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserID", DbType="Int NOT NULL")]
		public int UserID
		{
			get
			{
				return this._UserID;
			}
			set
			{
				if ((this._UserID != value))
				{
					this._UserID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OperationPerformedAt", DbType="DateTime NOT NULL")]
		public System.DateTime OperationPerformedAt
		{
			get
			{
				return this._OperationPerformedAt;
			}
			set
			{
				if ((this._OperationPerformedAt != value))
				{
					this._OperationPerformedAt = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ReturnedAt", DbType="DateTime NOT NULL")]
		public System.DateTime ReturnedAt
		{
			get
			{
				return this._ReturnedAt;
			}
			set
			{
				if ((this._ReturnedAt != value))
				{
					this._ReturnedAt = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Remarks", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Remarks
		{
			get
			{
				return this._Remarks;
			}
			set
			{
				if ((this._Remarks != value))
				{
					this._Remarks = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PerformedByID", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string PerformedByID
		{
			get
			{
				return this._PerformedByID;
			}
			set
			{
				if ((this._PerformedByID != value))
				{
					this._PerformedByID = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tbl_BookModel")]
	public partial class tbl_BookModel : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _BookID;
		
		private string _Name;
		
		private string _AuthorName;
		
		private string _Department;
		
		private bool _IsActive;
		
		private bool _IsAvailable;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnBookIDChanging(int value);
    partial void OnBookIDChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnAuthorNameChanging(string value);
    partial void OnAuthorNameChanged();
    partial void OnDepartmentChanging(string value);
    partial void OnDepartmentChanged();
    partial void OnIsActiveChanging(bool value);
    partial void OnIsActiveChanged();
    partial void OnIsAvailableChanging(bool value);
    partial void OnIsAvailableChanged();
    #endregion
		
		public tbl_BookModel()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BookID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int BookID
		{
			get
			{
				return this._BookID;
			}
			set
			{
				if ((this._BookID != value))
				{
					this.OnBookIDChanging(value);
					this.SendPropertyChanging();
					this._BookID = value;
					this.SendPropertyChanged("BookID");
					this.OnBookIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AuthorName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string AuthorName
		{
			get
			{
				return this._AuthorName;
			}
			set
			{
				if ((this._AuthorName != value))
				{
					this.OnAuthorNameChanging(value);
					this.SendPropertyChanging();
					this._AuthorName = value;
					this.SendPropertyChanged("AuthorName");
					this.OnAuthorNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Department", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Department
		{
			get
			{
				return this._Department;
			}
			set
			{
				if ((this._Department != value))
				{
					this.OnDepartmentChanging(value);
					this.SendPropertyChanging();
					this._Department = value;
					this.SendPropertyChanged("Department");
					this.OnDepartmentChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsActive", DbType="Bit NOT NULL")]
		public bool IsActive
		{
			get
			{
				return this._IsActive;
			}
			set
			{
				if ((this._IsActive != value))
				{
					this.OnIsActiveChanging(value);
					this.SendPropertyChanging();
					this._IsActive = value;
					this.SendPropertyChanged("IsActive");
					this.OnIsActiveChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsAvailable", DbType="Bit NOT NULL")]
		public bool IsAvailable
		{
			get
			{
				return this._IsAvailable;
			}
			set
			{
				if ((this._IsAvailable != value))
				{
					this.OnIsAvailableChanging(value);
					this.SendPropertyChanging();
					this._IsAvailable = value;
					this.SendPropertyChanged("IsAvailable");
					this.OnIsAvailableChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tbl_UserModel")]
	public partial class tbl_UserModel : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _UserID;
		
		private string _Name;
		
		private string _Email;
		
		private string _Password;
		
		private bool _IsActive;
		
		private bool _IsAdmin;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUserIDChanging(int value);
    partial void OnUserIDChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    partial void OnPasswordChanging(string value);
    partial void OnPasswordChanged();
    partial void OnIsActiveChanging(bool value);
    partial void OnIsActiveChanged();
    partial void OnIsAdminChanging(bool value);
    partial void OnIsAdminChanged();
    #endregion
		
		public tbl_UserModel()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int UserID
		{
			get
			{
				return this._UserID;
			}
			set
			{
				if ((this._UserID != value))
				{
					this.OnUserIDChanging(value);
					this.SendPropertyChanging();
					this._UserID = value;
					this.SendPropertyChanged("UserID");
					this.OnUserIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this.OnEmailChanging(value);
					this.SendPropertyChanging();
					this._Email = value;
					this.SendPropertyChanged("Email");
					this.OnEmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Password", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Password
		{
			get
			{
				return this._Password;
			}
			set
			{
				if ((this._Password != value))
				{
					this.OnPasswordChanging(value);
					this.SendPropertyChanging();
					this._Password = value;
					this.SendPropertyChanged("Password");
					this.OnPasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsActive", DbType="Bit NOT NULL")]
		public bool IsActive
		{
			get
			{
				return this._IsActive;
			}
			set
			{
				if ((this._IsActive != value))
				{
					this.OnIsActiveChanging(value);
					this.SendPropertyChanging();
					this._IsActive = value;
					this.SendPropertyChanged("IsActive");
					this.OnIsActiveChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsAdmin", DbType="Bit NOT NULL")]
		public bool IsAdmin
		{
			get
			{
				return this._IsAdmin;
			}
			set
			{
				if ((this._IsAdmin != value))
				{
					this.OnIsAdminChanging(value);
					this.SendPropertyChanging();
					this._IsAdmin = value;
					this.SendPropertyChanged("IsAdmin");
					this.OnIsAdminChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591