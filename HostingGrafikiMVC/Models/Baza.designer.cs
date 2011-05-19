﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.225
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HostingGrafikiMVC.Models
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="HostingGrafiki")]
	public partial class BazaDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertPliki(Pliki instance);
    partial void UpdatePliki(Pliki instance);
    partial void DeletePliki(Pliki instance);
    partial void InsertUsuwanie(Usuwanie instance);
    partial void UpdateUsuwanie(Usuwanie instance);
    partial void DeleteUsuwanie(Usuwanie instance);
    #endregion
		
		public BazaDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["HostingGrafikiConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public BazaDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public BazaDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public BazaDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public BazaDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Pliki> Plikis
		{
			get
			{
				return this.GetTable<Pliki>();
			}
		}
		
		public System.Data.Linq.Table<Usuwanie> Usuwanies
		{
			get
			{
				return this.GetTable<Usuwanie>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Pliki")]
	public partial class Pliki : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _NazwaPliku;
		
		private string _GUID;
		
		private int _Prywatny;
		
		private EntitySet<Usuwanie> _Usuwanies;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnNazwaPlikuChanging(string value);
    partial void OnNazwaPlikuChanged();
    partial void OnGUIDChanging(string value);
    partial void OnGUIDChanged();
    partial void OnPrywatnyChanging(int value);
    partial void OnPrywatnyChanged();
    #endregion
		
		public Pliki()
		{
			this._Usuwanies = new EntitySet<Usuwanie>(new Action<Usuwanie>(this.attach_Usuwanies), new Action<Usuwanie>(this.detach_Usuwanies));
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NazwaPliku", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string NazwaPliku
		{
			get
			{
				return this._NazwaPliku;
			}
			set
			{
				if ((this._NazwaPliku != value))
				{
					this.OnNazwaPlikuChanging(value);
					this.SendPropertyChanging();
					this._NazwaPliku = value;
					this.SendPropertyChanged("NazwaPliku");
					this.OnNazwaPlikuChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GUID", DbType="VarChar(30) NOT NULL", CanBeNull=false)]
		public string GUID
		{
			get
			{
				return this._GUID;
			}
			set
			{
				if ((this._GUID != value))
				{
					this.OnGUIDChanging(value);
					this.SendPropertyChanging();
					this._GUID = value;
					this.SendPropertyChanged("GUID");
					this.OnGUIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Prywatny", DbType="Int NOT NULL")]
		public int Prywatny
		{
			get
			{
				return this._Prywatny;
			}
			set
			{
				if ((this._Prywatny != value))
				{
					this.OnPrywatnyChanging(value);
					this.SendPropertyChanging();
					this._Prywatny = value;
					this.SendPropertyChanged("Prywatny");
					this.OnPrywatnyChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Pliki_Usuwanie", Storage="_Usuwanies", ThisKey="ID", OtherKey="IDPliku")]
		public EntitySet<Usuwanie> Usuwanies
		{
			get
			{
				return this._Usuwanies;
			}
			set
			{
				this._Usuwanies.Assign(value);
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
		
		private void attach_Usuwanies(Usuwanie entity)
		{
			this.SendPropertyChanging();
			entity.Pliki = this;
		}
		
		private void detach_Usuwanies(Usuwanie entity)
		{
			this.SendPropertyChanging();
			entity.Pliki = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Usuwanie")]
	public partial class Usuwanie : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private int _IDPliku;
		
		private string _GUID;
		
		private EntityRef<Pliki> _Pliki;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnIDPlikuChanging(int value);
    partial void OnIDPlikuChanged();
    partial void OnGUIDChanging(string value);
    partial void OnGUIDChanged();
    #endregion
		
		public Usuwanie()
		{
			this._Pliki = default(EntityRef<Pliki>);
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDPliku", DbType="Int NOT NULL")]
		public int IDPliku
		{
			get
			{
				return this._IDPliku;
			}
			set
			{
				if ((this._IDPliku != value))
				{
					if (this._Pliki.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIDPlikuChanging(value);
					this.SendPropertyChanging();
					this._IDPliku = value;
					this.SendPropertyChanged("IDPliku");
					this.OnIDPlikuChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GUID", DbType="VarChar(36) NOT NULL", CanBeNull=false)]
		public string GUID
		{
			get
			{
				return this._GUID;
			}
			set
			{
				if ((this._GUID != value))
				{
					this.OnGUIDChanging(value);
					this.SendPropertyChanging();
					this._GUID = value;
					this.SendPropertyChanged("GUID");
					this.OnGUIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Pliki_Usuwanie", Storage="_Pliki", ThisKey="IDPliku", OtherKey="ID", IsForeignKey=true)]
		public Pliki Pliki
		{
			get
			{
				return this._Pliki.Entity;
			}
			set
			{
				Pliki previousValue = this._Pliki.Entity;
				if (((previousValue != value) 
							|| (this._Pliki.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Pliki.Entity = null;
						previousValue.Usuwanies.Remove(this);
					}
					this._Pliki.Entity = value;
					if ((value != null))
					{
						value.Usuwanies.Add(this);
						this._IDPliku = value.ID;
					}
					else
					{
						this._IDPliku = default(int);
					}
					this.SendPropertyChanged("Pliki");
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
