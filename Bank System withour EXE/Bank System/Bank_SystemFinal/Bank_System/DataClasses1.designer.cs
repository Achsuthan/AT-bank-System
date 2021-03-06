﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.33440
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bank_System
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Bank_System")]
	public partial class DataClasses1DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void Insertbranch(branch instance);
    partial void Updatebranch(branch instance);
    partial void Deletebranch(branch instance);
    partial void Insertcustomer(customer instance);
    partial void Updatecustomer(customer instance);
    partial void Deletecustomer(customer instance);
    partial void Insertaccount(account instance);
    partial void Updateaccount(account instance);
    partial void Deleteaccount(account instance);
    #endregion
		
		public DataClasses1DataContext() : 
				base(global::Bank_System.Properties.Settings.Default.Bank_SystemConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<admin> admins
		{
			get
			{
				return this.GetTable<admin>();
			}
		}
		
		public System.Data.Linq.Table<branch> branches
		{
			get
			{
				return this.GetTable<branch>();
			}
		}
		
		public System.Data.Linq.Table<customer> customers
		{
			get
			{
				return this.GetTable<customer>();
			}
		}
		
		public System.Data.Linq.Table<intrest> intrests
		{
			get
			{
				return this.GetTable<intrest>();
			}
		}
		
		public System.Data.Linq.Table<account> accounts
		{
			get
			{
				return this.GetTable<account>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.admin")]
	public partial class admin
	{
		
		private string _username;
		
		private string _password;
		
		public admin()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_username", DbType="VarChar(80)")]
		public string username
		{
			get
			{
				return this._username;
			}
			set
			{
				if ((this._username != value))
				{
					this._username = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_password", DbType="VarChar(80)")]
		public string password
		{
			get
			{
				return this._password;
			}
			set
			{
				if ((this._password != value))
				{
					this._password = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.branch")]
	public partial class branch : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _BranchID;
		
		private string _Name;
		
		private string _Address;
		
		private EntitySet<account> _accounts;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnBranchIDChanging(string value);
    partial void OnBranchIDChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnAddressChanging(string value);
    partial void OnAddressChanged();
    #endregion
		
		public branch()
		{
			this._accounts = new EntitySet<account>(new Action<account>(this.attach_accounts), new Action<account>(this.detach_accounts));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BranchID", DbType="VarChar(10) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string BranchID
		{
			get
			{
				return this._BranchID;
			}
			set
			{
				if ((this._BranchID != value))
				{
					this.OnBranchIDChanging(value);
					this.SendPropertyChanging();
					this._BranchID = value;
					this.SendPropertyChanged("BranchID");
					this.OnBranchIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="VarChar(30)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Address", DbType="VarChar(80)")]
		public string Address
		{
			get
			{
				return this._Address;
			}
			set
			{
				if ((this._Address != value))
				{
					this.OnAddressChanging(value);
					this.SendPropertyChanging();
					this._Address = value;
					this.SendPropertyChanged("Address");
					this.OnAddressChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="branch_account", Storage="_accounts", ThisKey="BranchID", OtherKey="BranchID")]
		public EntitySet<account> accounts
		{
			get
			{
				return this._accounts;
			}
			set
			{
				this._accounts.Assign(value);
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
		
		private void attach_accounts(account entity)
		{
			this.SendPropertyChanging();
			entity.branch = this;
		}
		
		private void detach_accounts(account entity)
		{
			this.SendPropertyChanging();
			entity.branch = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.customer")]
	public partial class customer : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _CustomerID;
		
		private string _CustomerName;
		
		private string _NIC;
		
		private string _Gender;
		
		private System.Nullable<int> _Age;
		
		private string _Address;
		
		private string _Income;
		
		private EntitySet<account> _accounts;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnCustomerIDChanging(string value);
    partial void OnCustomerIDChanged();
    partial void OnCustomerNameChanging(string value);
    partial void OnCustomerNameChanged();
    partial void OnNICChanging(string value);
    partial void OnNICChanged();
    partial void OnGenderChanging(string value);
    partial void OnGenderChanged();
    partial void OnAgeChanging(System.Nullable<int> value);
    partial void OnAgeChanged();
    partial void OnAddressChanging(string value);
    partial void OnAddressChanged();
    partial void OnIncomeChanging(string value);
    partial void OnIncomeChanged();
    #endregion
		
		public customer()
		{
			this._accounts = new EntitySet<account>(new Action<account>(this.attach_accounts), new Action<account>(this.detach_accounts));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CustomerID", DbType="VarChar(20) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string CustomerID
		{
			get
			{
				return this._CustomerID;
			}
			set
			{
				if ((this._CustomerID != value))
				{
					this.OnCustomerIDChanging(value);
					this.SendPropertyChanging();
					this._CustomerID = value;
					this.SendPropertyChanged("CustomerID");
					this.OnCustomerIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CustomerName", DbType="VarChar(40)")]
		public string CustomerName
		{
			get
			{
				return this._CustomerName;
			}
			set
			{
				if ((this._CustomerName != value))
				{
					this.OnCustomerNameChanging(value);
					this.SendPropertyChanging();
					this._CustomerName = value;
					this.SendPropertyChanged("CustomerName");
					this.OnCustomerNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NIC", DbType="VarChar(14)")]
		public string NIC
		{
			get
			{
				return this._NIC;
			}
			set
			{
				if ((this._NIC != value))
				{
					this.OnNICChanging(value);
					this.SendPropertyChanging();
					this._NIC = value;
					this.SendPropertyChanged("NIC");
					this.OnNICChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Gender", DbType="VarChar(8)")]
		public string Gender
		{
			get
			{
				return this._Gender;
			}
			set
			{
				if ((this._Gender != value))
				{
					this.OnGenderChanging(value);
					this.SendPropertyChanging();
					this._Gender = value;
					this.SendPropertyChanged("Gender");
					this.OnGenderChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Age", DbType="Int")]
		public System.Nullable<int> Age
		{
			get
			{
				return this._Age;
			}
			set
			{
				if ((this._Age != value))
				{
					this.OnAgeChanging(value);
					this.SendPropertyChanging();
					this._Age = value;
					this.SendPropertyChanged("Age");
					this.OnAgeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Address", DbType="VarChar(80)")]
		public string Address
		{
			get
			{
				return this._Address;
			}
			set
			{
				if ((this._Address != value))
				{
					this.OnAddressChanging(value);
					this.SendPropertyChanging();
					this._Address = value;
					this.SendPropertyChanged("Address");
					this.OnAddressChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Income", DbType="VarChar(30)")]
		public string Income
		{
			get
			{
				return this._Income;
			}
			set
			{
				if ((this._Income != value))
				{
					this.OnIncomeChanging(value);
					this.SendPropertyChanging();
					this._Income = value;
					this.SendPropertyChanged("Income");
					this.OnIncomeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="customer_account", Storage="_accounts", ThisKey="CustomerID", OtherKey="CustomerID")]
		public EntitySet<account> accounts
		{
			get
			{
				return this._accounts;
			}
			set
			{
				this._accounts.Assign(value);
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
		
		private void attach_accounts(account entity)
		{
			this.SendPropertyChanging();
			entity.customer = this;
		}
		
		private void detach_accounts(account entity)
		{
			this.SendPropertyChanging();
			entity.customer = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.intrest")]
	public partial class intrest
	{
		
		private string _Type;
		
		private string _Rate;
		
		public intrest()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Type", DbType="VarChar(10)")]
		public string Type
		{
			get
			{
				return this._Type;
			}
			set
			{
				if ((this._Type != value))
				{
					this._Type = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Rate", DbType="VarChar(10)")]
		public string Rate
		{
			get
			{
				return this._Rate;
			}
			set
			{
				if ((this._Rate != value))
				{
					this._Rate = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.account")]
	public partial class account : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _AccountNumber;
		
		private string _AccountType;
		
		private string _IntrestRate;
		
		private string _DateAccountOpen;
		
		private System.Nullable<double> _AccountBalance;
		
		private string _BranchID;
		
		private string _CustomerID;
		
		private EntityRef<branch> _branch;
		
		private EntityRef<customer> _customer;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnAccountNumberChanging(string value);
    partial void OnAccountNumberChanged();
    partial void OnAccountTypeChanging(string value);
    partial void OnAccountTypeChanged();
    partial void OnIntrestRateChanging(string value);
    partial void OnIntrestRateChanged();
    partial void OnDateAccountOpenChanging(string value);
    partial void OnDateAccountOpenChanged();
    partial void OnAccountBalanceChanging(System.Nullable<double> value);
    partial void OnAccountBalanceChanged();
    partial void OnBranchIDChanging(string value);
    partial void OnBranchIDChanged();
    partial void OnCustomerIDChanging(string value);
    partial void OnCustomerIDChanged();
    #endregion
		
		public account()
		{
			this._branch = default(EntityRef<branch>);
			this._customer = default(EntityRef<customer>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AccountNumber", DbType="VarChar(30) NOT NULL", CanBeNull=false)]
		public string AccountNumber
		{
			get
			{
				return this._AccountNumber;
			}
			set
			{
				if ((this._AccountNumber != value))
				{
					this.OnAccountNumberChanging(value);
					this.SendPropertyChanging();
					this._AccountNumber = value;
					this.SendPropertyChanged("AccountNumber");
					this.OnAccountNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AccountType", DbType="VarChar(10)")]
		public string AccountType
		{
			get
			{
				return this._AccountType;
			}
			set
			{
				if ((this._AccountType != value))
				{
					this.OnAccountTypeChanging(value);
					this.SendPropertyChanging();
					this._AccountType = value;
					this.SendPropertyChanged("AccountType");
					this.OnAccountTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IntrestRate", DbType="VarChar(10)")]
		public string IntrestRate
		{
			get
			{
				return this._IntrestRate;
			}
			set
			{
				if ((this._IntrestRate != value))
				{
					this.OnIntrestRateChanging(value);
					this.SendPropertyChanging();
					this._IntrestRate = value;
					this.SendPropertyChanged("IntrestRate");
					this.OnIntrestRateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DateAccountOpen", DbType="VarChar(30)")]
		public string DateAccountOpen
		{
			get
			{
				return this._DateAccountOpen;
			}
			set
			{
				if ((this._DateAccountOpen != value))
				{
					this.OnDateAccountOpenChanging(value);
					this.SendPropertyChanging();
					this._DateAccountOpen = value;
					this.SendPropertyChanged("DateAccountOpen");
					this.OnDateAccountOpenChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AccountBalance", DbType="Float")]
		public System.Nullable<double> AccountBalance
		{
			get
			{
				return this._AccountBalance;
			}
			set
			{
				if ((this._AccountBalance != value))
				{
					this.OnAccountBalanceChanging(value);
					this.SendPropertyChanging();
					this._AccountBalance = value;
					this.SendPropertyChanged("AccountBalance");
					this.OnAccountBalanceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BranchID", DbType="VarChar(10)")]
		public string BranchID
		{
			get
			{
				return this._BranchID;
			}
			set
			{
				if ((this._BranchID != value))
				{
					if (this._branch.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnBranchIDChanging(value);
					this.SendPropertyChanging();
					this._BranchID = value;
					this.SendPropertyChanged("BranchID");
					this.OnBranchIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CustomerID", DbType="VarChar(20)")]
		public string CustomerID
		{
			get
			{
				return this._CustomerID;
			}
			set
			{
				if ((this._CustomerID != value))
				{
					if (this._customer.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnCustomerIDChanging(value);
					this.SendPropertyChanging();
					this._CustomerID = value;
					this.SendPropertyChanged("CustomerID");
					this.OnCustomerIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="branch_account", Storage="_branch", ThisKey="BranchID", OtherKey="BranchID", IsForeignKey=true)]
		public branch branch
		{
			get
			{
				return this._branch.Entity;
			}
			set
			{
				branch previousValue = this._branch.Entity;
				if (((previousValue != value) 
							|| (this._branch.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._branch.Entity = null;
						previousValue.accounts.Remove(this);
					}
					this._branch.Entity = value;
					if ((value != null))
					{
						value.accounts.Add(this);
						this._BranchID = value.BranchID;
					}
					else
					{
						this._BranchID = default(string);
					}
					this.SendPropertyChanged("branch");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="customer_account", Storage="_customer", ThisKey="CustomerID", OtherKey="CustomerID", IsForeignKey=true)]
		public customer customer
		{
			get
			{
				return this._customer.Entity;
			}
			set
			{
				customer previousValue = this._customer.Entity;
				if (((previousValue != value) 
							|| (this._customer.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._customer.Entity = null;
						previousValue.accounts.Remove(this);
					}
					this._customer.Entity = value;
					if ((value != null))
					{
						value.accounts.Add(this);
						this._CustomerID = value.CustomerID;
					}
					else
					{
						this._CustomerID = default(string);
					}
					this.SendPropertyChanged("customer");
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
