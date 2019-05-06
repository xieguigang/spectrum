﻿Imports System.IO
Imports Microsoft.VisualBasic.Data.csv.IO.Linq

Namespace TMIC.HMDB

    Public Class ChemicalDescriptor

        ''' <summary>
        ''' HMDB main accession
        ''' </summary>
        ''' <returns></returns>
        Public Property accession As String
        Public Property name As String
        Public Property kegg_id As String
        Public Property state As String
        Public Property melting_point As Double
        Public Property logp As Double
        Public Property pka_strongest_acidic As Double
        Public Property pka_strongest_basic As Double
        Public Property polar_surface_area As Double
        Public Property refractivity As Double
        Public Property polarizability As Double
        Public Property rotatable_bond_count As Double
        Public Property acceptor_count As Double
        Public Property donor_count As Double
        Public Property physiological_charge As Double
        Public Property formal_charge As Double
        Public Property number_of_rings As Double
        Public Property bioavailability As Double
        Public Property rule_of_five As String
        Public Property ghose_filter As String
        Public Property veber_rule As String
        Public Property mddr_like_rule As String

        Public Shared Function FromMetabolite(metabolite As metabolite) As ChemicalDescriptor
            Dim properties = metabolite.experimental_properties.PropertyList.AsList +
                metabolite.predicted_properties.PropertyList
            Dim propertyTable As Dictionary(Of String, String) = properties _
                .GroupBy(Function(p) p.kind) _
                .ToDictionary(Function(p) p.Key,
                              Function(g)
                                  If g.Any(Function(f) IsBooleanFactor(f.value)) Then
                                      Return g.Select(Function(x) x.value).TopMostFrequent
                                  Else
                                      Return g.Select(Function(x) Val(x.value)) _
                                         .Average _
                                         .ToString
                                  End If
                              End Function)
            Dim read = Function(key As String, default$) As String
                           Return propertyTable.TryGetValue(key, [default]:=[default])
                       End Function

            Return New ChemicalDescriptor With {
                .accession = metabolite.accession,
                .name = metabolite.name,
                .kegg_id = metabolite.kegg_id,
                .state = metabolite.state,
                .acceptor_count = read(NameOf(.acceptor_count), 0),
                .bioavailability = read(NameOf(.bioavailability), 0),
                .donor_count = read(NameOf(.donor_count), 0),
                .formal_charge = read(NameOf(.formal_charge), 0),
                .ghose_filter = read(NameOf(.ghose_filter), "no"),
                .logp = read(NameOf(.logp), 0),
                .mddr_like_rule = read(NameOf(.mddr_like_rule), "no"),
                .melting_point = read(NameOf(melting_point), 0),
                .number_of_rings = read(NameOf(.number_of_rings), 0),
                .physiological_charge = read(NameOf(.physiological_charge), 0),
                .pka_strongest_acidic = read(NameOf(.pka_strongest_acidic), 0),
                .pka_strongest_basic = read(NameOf(.pka_strongest_basic), 0),
                .polarizability = read(NameOf(.polarizability), 0),
                .polar_surface_area = read(NameOf(.polar_surface_area), 0),
                .refractivity = read(NameOf(.refractivity), 0),
                .rotatable_bond_count = read(NameOf(.rotatable_bond_count), 0),
                .rule_of_five = read(NameOf(.rule_of_five), "no"),
                .veber_rule = read(NameOf(.veber_rule), "no")
            }
        End Function

        Public Shared Sub WriteTable(metabolites As IEnumerable(Of metabolite), out As Stream)
            Using table As New WriteStream(Of ChemicalDescriptor)(New StreamWriter(out))
                For Each metabolite As metabolite In metabolites
                    Call table.Flush(FromMetabolite(metabolite))
                Next
            End Using
        End Sub
    End Class
End Namespace