REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @2019/9/4 10:04:38


Imports System.Data.Linq.Mapping
Imports System.Xml.Serialization
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace mysql

''' <summary>
''' ```SQL
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("descriptor", Database:="pubchem", SchemaSQL:="
CREATE TABLE IF NOT EXISTS `pubchem`.`descriptor` (
  `cid` INT NOT NULL,
  `complexity` FLOAT NULL,
  `hbond_acceptor` VARCHAR(45) NULL,
  `hbond_donor` VARCHAR(45) NULL,
  `rotatable_bond` VARCHAR(45) NULL,
  `subkeys` VARCHAR(45) NULL,
  `xlogp3_aa` VARCHAR(45) NULL,
  `exact_mass` VARCHAR(45) NULL,
  `formula` VARCHAR(45) NULL,
  `molecular_weight` VARCHAR(45) NULL,
  `can_smiles` VARCHAR(45) NULL,
  `iso_smiles` VARCHAR(45) NULL,
  `tpsa` VARCHAR(45) NULL,
  `monoisotopic_weight` VARCHAR(45) NULL,
  `total_charge` VARCHAR(45) NULL,
  `heavy_atom_count` VARCHAR(45) NULL,
  `atom_def_stereo_count` VARCHAR(45) NULL,
  `atom_udef_stereo_count` VARCHAR(45) NULL,
  `bond_def_stereo_count` VARCHAR(45) NULL,
  `bond_udef_stereo_count` VARCHAR(45) NULL,
  `isotopic_atom_count` VARCHAR(45) NULL,
  `component_count` VARCHAR(45) NULL,
  `tauto_count` VARCHAR(45) NULL,
  PRIMARY KEY (`cid`),
  UNIQUE INDEX `cid_UNIQUE` (`cid` ASC))
ENGINE = InnoDB;
")>
Public Class descriptor: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("cid"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "11"), Column(Name:="cid"), XmlAttribute> Public Property cid As Long
    <DatabaseField("complexity"), DataType(MySqlDbType.Double), Column(Name:="complexity")> Public Property complexity As Double
    <DatabaseField("hbond_acceptor"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="hbond_acceptor")> Public Property hbond_acceptor As String
    <DatabaseField("hbond_donor"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="hbond_donor")> Public Property hbond_donor As String
    <DatabaseField("rotatable_bond"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="rotatable_bond")> Public Property rotatable_bond As String
    <DatabaseField("subkeys"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="subkeys")> Public Property subkeys As String
    <DatabaseField("xlogp3_aa"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="xlogp3_aa")> Public Property xlogp3_aa As String
    <DatabaseField("exact_mass"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="exact_mass")> Public Property exact_mass As String
    <DatabaseField("formula"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="formula")> Public Property formula As String
    <DatabaseField("molecular_weight"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="molecular_weight")> Public Property molecular_weight As String
    <DatabaseField("can_smiles"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="can_smiles")> Public Property can_smiles As String
    <DatabaseField("iso_smiles"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="iso_smiles")> Public Property iso_smiles As String
    <DatabaseField("tpsa"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="tpsa")> Public Property tpsa As String
    <DatabaseField("monoisotopic_weight"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="monoisotopic_weight")> Public Property monoisotopic_weight As String
    <DatabaseField("total_charge"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="total_charge")> Public Property total_charge As String
    <DatabaseField("heavy_atom_count"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="heavy_atom_count")> Public Property heavy_atom_count As String
    <DatabaseField("atom_def_stereo_count"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="atom_def_stereo_count")> Public Property atom_def_stereo_count As String
    <DatabaseField("atom_udef_stereo_count"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="atom_udef_stereo_count")> Public Property atom_udef_stereo_count As String
    <DatabaseField("bond_def_stereo_count"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="bond_def_stereo_count")> Public Property bond_def_stereo_count As String
    <DatabaseField("bond_udef_stereo_count"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="bond_udef_stereo_count")> Public Property bond_udef_stereo_count As String
    <DatabaseField("isotopic_atom_count"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="isotopic_atom_count")> Public Property isotopic_atom_count As String
    <DatabaseField("component_count"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="component_count")> Public Property component_count As String
    <DatabaseField("tauto_count"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="tauto_count")> Public Property tauto_count As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `descriptor` (`cid`, `complexity`, `hbond_acceptor`, `hbond_donor`, `rotatable_bond`, `subkeys`, `xlogp3_aa`, `exact_mass`, `formula`, `molecular_weight`, `can_smiles`, `iso_smiles`, `tpsa`, `monoisotopic_weight`, `total_charge`, `heavy_atom_count`, `atom_def_stereo_count`, `atom_udef_stereo_count`, `bond_def_stereo_count`, `bond_udef_stereo_count`, `isotopic_atom_count`, `component_count`, `tauto_count`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}', '{22}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `descriptor` (`cid`, `complexity`, `hbond_acceptor`, `hbond_donor`, `rotatable_bond`, `subkeys`, `xlogp3_aa`, `exact_mass`, `formula`, `molecular_weight`, `can_smiles`, `iso_smiles`, `tpsa`, `monoisotopic_weight`, `total_charge`, `heavy_atom_count`, `atom_def_stereo_count`, `atom_udef_stereo_count`, `bond_def_stereo_count`, `bond_udef_stereo_count`, `isotopic_atom_count`, `component_count`, `tauto_count`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}', '{22}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `descriptor` (`cid`, `complexity`, `hbond_acceptor`, `hbond_donor`, `rotatable_bond`, `subkeys`, `xlogp3_aa`, `exact_mass`, `formula`, `molecular_weight`, `can_smiles`, `iso_smiles`, `tpsa`, `monoisotopic_weight`, `total_charge`, `heavy_atom_count`, `atom_def_stereo_count`, `atom_udef_stereo_count`, `bond_def_stereo_count`, `bond_udef_stereo_count`, `isotopic_atom_count`, `component_count`, `tauto_count`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}', '{22}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `descriptor` (`cid`, `complexity`, `hbond_acceptor`, `hbond_donor`, `rotatable_bond`, `subkeys`, `xlogp3_aa`, `exact_mass`, `formula`, `molecular_weight`, `can_smiles`, `iso_smiles`, `tpsa`, `monoisotopic_weight`, `total_charge`, `heavy_atom_count`, `atom_def_stereo_count`, `atom_udef_stereo_count`, `bond_def_stereo_count`, `bond_udef_stereo_count`, `isotopic_atom_count`, `component_count`, `tauto_count`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}', '{22}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `descriptor` WHERE `cid` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `descriptor` SET `cid`='{0}', `complexity`='{1}', `hbond_acceptor`='{2}', `hbond_donor`='{3}', `rotatable_bond`='{4}', `subkeys`='{5}', `xlogp3_aa`='{6}', `exact_mass`='{7}', `formula`='{8}', `molecular_weight`='{9}', `can_smiles`='{10}', `iso_smiles`='{11}', `tpsa`='{12}', `monoisotopic_weight`='{13}', `total_charge`='{14}', `heavy_atom_count`='{15}', `atom_def_stereo_count`='{16}', `atom_udef_stereo_count`='{17}', `bond_def_stereo_count`='{18}', `bond_udef_stereo_count`='{19}', `isotopic_atom_count`='{20}', `component_count`='{21}', `tauto_count`='{22}' WHERE `cid` = '{23}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `descriptor` WHERE `cid` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, cid)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `descriptor` (`cid`, `complexity`, `hbond_acceptor`, `hbond_donor`, `rotatable_bond`, `subkeys`, `xlogp3_aa`, `exact_mass`, `formula`, `molecular_weight`, `can_smiles`, `iso_smiles`, `tpsa`, `monoisotopic_weight`, `total_charge`, `heavy_atom_count`, `atom_def_stereo_count`, `atom_udef_stereo_count`, `bond_def_stereo_count`, `bond_udef_stereo_count`, `isotopic_atom_count`, `component_count`, `tauto_count`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}', '{22}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, cid, complexity, hbond_acceptor, hbond_donor, rotatable_bond, subkeys, xlogp3_aa, exact_mass, formula, molecular_weight, can_smiles, iso_smiles, tpsa, monoisotopic_weight, total_charge, heavy_atom_count, atom_def_stereo_count, atom_udef_stereo_count, bond_def_stereo_count, bond_udef_stereo_count, isotopic_atom_count, component_count, tauto_count)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `descriptor` (`cid`, `complexity`, `hbond_acceptor`, `hbond_donor`, `rotatable_bond`, `subkeys`, `xlogp3_aa`, `exact_mass`, `formula`, `molecular_weight`, `can_smiles`, `iso_smiles`, `tpsa`, `monoisotopic_weight`, `total_charge`, `heavy_atom_count`, `atom_def_stereo_count`, `atom_udef_stereo_count`, `bond_def_stereo_count`, `bond_udef_stereo_count`, `isotopic_atom_count`, `component_count`, `tauto_count`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}', '{22}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, cid, complexity, hbond_acceptor, hbond_donor, rotatable_bond, subkeys, xlogp3_aa, exact_mass, formula, molecular_weight, can_smiles, iso_smiles, tpsa, monoisotopic_weight, total_charge, heavy_atom_count, atom_def_stereo_count, atom_udef_stereo_count, bond_def_stereo_count, bond_udef_stereo_count, isotopic_atom_count, component_count, tauto_count)
        Else
        Return String.Format(INSERT_SQL, cid, complexity, hbond_acceptor, hbond_donor, rotatable_bond, subkeys, xlogp3_aa, exact_mass, formula, molecular_weight, can_smiles, iso_smiles, tpsa, monoisotopic_weight, total_charge, heavy_atom_count, atom_def_stereo_count, atom_udef_stereo_count, bond_def_stereo_count, bond_udef_stereo_count, isotopic_atom_count, component_count, tauto_count)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue(AI As Boolean) As String
        If AI Then
            Return $"('{cid}', '{complexity}', '{hbond_acceptor}', '{hbond_donor}', '{rotatable_bond}', '{subkeys}', '{xlogp3_aa}', '{exact_mass}', '{formula}', '{molecular_weight}', '{can_smiles}', '{iso_smiles}', '{tpsa}', '{monoisotopic_weight}', '{total_charge}', '{heavy_atom_count}', '{atom_def_stereo_count}', '{atom_udef_stereo_count}', '{bond_def_stereo_count}', '{bond_udef_stereo_count}', '{isotopic_atom_count}', '{component_count}', '{tauto_count}')"
        Else
            Return $"('{cid}', '{complexity}', '{hbond_acceptor}', '{hbond_donor}', '{rotatable_bond}', '{subkeys}', '{xlogp3_aa}', '{exact_mass}', '{formula}', '{molecular_weight}', '{can_smiles}', '{iso_smiles}', '{tpsa}', '{monoisotopic_weight}', '{total_charge}', '{heavy_atom_count}', '{atom_def_stereo_count}', '{atom_udef_stereo_count}', '{bond_def_stereo_count}', '{bond_udef_stereo_count}', '{isotopic_atom_count}', '{component_count}', '{tauto_count}')"
        End If
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `descriptor` (`cid`, `complexity`, `hbond_acceptor`, `hbond_donor`, `rotatable_bond`, `subkeys`, `xlogp3_aa`, `exact_mass`, `formula`, `molecular_weight`, `can_smiles`, `iso_smiles`, `tpsa`, `monoisotopic_weight`, `total_charge`, `heavy_atom_count`, `atom_def_stereo_count`, `atom_udef_stereo_count`, `bond_def_stereo_count`, `bond_udef_stereo_count`, `isotopic_atom_count`, `component_count`, `tauto_count`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}', '{22}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, cid, complexity, hbond_acceptor, hbond_donor, rotatable_bond, subkeys, xlogp3_aa, exact_mass, formula, molecular_weight, can_smiles, iso_smiles, tpsa, monoisotopic_weight, total_charge, heavy_atom_count, atom_def_stereo_count, atom_udef_stereo_count, bond_def_stereo_count, bond_udef_stereo_count, isotopic_atom_count, component_count, tauto_count)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `descriptor` (`cid`, `complexity`, `hbond_acceptor`, `hbond_donor`, `rotatable_bond`, `subkeys`, `xlogp3_aa`, `exact_mass`, `formula`, `molecular_weight`, `can_smiles`, `iso_smiles`, `tpsa`, `monoisotopic_weight`, `total_charge`, `heavy_atom_count`, `atom_def_stereo_count`, `atom_udef_stereo_count`, `bond_def_stereo_count`, `bond_udef_stereo_count`, `isotopic_atom_count`, `component_count`, `tauto_count`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}', '{22}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, cid, complexity, hbond_acceptor, hbond_donor, rotatable_bond, subkeys, xlogp3_aa, exact_mass, formula, molecular_weight, can_smiles, iso_smiles, tpsa, monoisotopic_weight, total_charge, heavy_atom_count, atom_def_stereo_count, atom_udef_stereo_count, bond_def_stereo_count, bond_udef_stereo_count, isotopic_atom_count, component_count, tauto_count)
        Else
        Return String.Format(REPLACE_SQL, cid, complexity, hbond_acceptor, hbond_donor, rotatable_bond, subkeys, xlogp3_aa, exact_mass, formula, molecular_weight, can_smiles, iso_smiles, tpsa, monoisotopic_weight, total_charge, heavy_atom_count, atom_def_stereo_count, atom_udef_stereo_count, bond_def_stereo_count, bond_udef_stereo_count, isotopic_atom_count, component_count, tauto_count)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `descriptor` SET `cid`='{0}', `complexity`='{1}', `hbond_acceptor`='{2}', `hbond_donor`='{3}', `rotatable_bond`='{4}', `subkeys`='{5}', `xlogp3_aa`='{6}', `exact_mass`='{7}', `formula`='{8}', `molecular_weight`='{9}', `can_smiles`='{10}', `iso_smiles`='{11}', `tpsa`='{12}', `monoisotopic_weight`='{13}', `total_charge`='{14}', `heavy_atom_count`='{15}', `atom_def_stereo_count`='{16}', `atom_udef_stereo_count`='{17}', `bond_def_stereo_count`='{18}', `bond_udef_stereo_count`='{19}', `isotopic_atom_count`='{20}', `component_count`='{21}', `tauto_count`='{22}' WHERE `cid` = '{23}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, cid, complexity, hbond_acceptor, hbond_donor, rotatable_bond, subkeys, xlogp3_aa, exact_mass, formula, molecular_weight, can_smiles, iso_smiles, tpsa, monoisotopic_weight, total_charge, heavy_atom_count, atom_def_stereo_count, atom_udef_stereo_count, bond_def_stereo_count, bond_udef_stereo_count, isotopic_atom_count, component_count, tauto_count, cid)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As descriptor
                         Return DirectCast(MyClass.MemberwiseClone, descriptor)
                     End Function
End Class


End Namespace
