﻿Imports BioNovoGene.BioDeep.Chemoinformatics.NaturalProduct
Imports Microsoft.VisualBasic.Serialization.JSON

Module nameTest

    Dim parser As New GlycosylNameSolver

    Sub Main()

        Call echo("  3-o-(6-o-(4-o-malonyl-alpha-rhamnopyranosyl)-beta-glucopyranoside)-5-o-beta-glucopyranoside")

        Call echo("Malvidin 3,7-di-(6-malonylglucoside)")
        Call echo("Delphinidin 3,5-di(6-acetylglucoside)")
        Call echo("Delphinidin 3,7,3'-triglucoside")
        Call echo("Delphinidin 3,7-diglucoside-3',5'-di(6-O-p-coumaroyl-beta-glucoside)")
        Call echo("Cyanidin 3-(6'',6'''-di-p-coumarylsophoroside)-5-(6-malonylglucoside)")
        Call echo("Cyanidin 3-O-[2''-O-(xylosyl)-6''-O-(p-coumaroyl) glucoside] 5-O-malonylglucoside")
        Call echo("Petunidin 3,5-di-O-beta-D-glucoside")

        Pause()
    End Sub

    Private Sub echo(name As String)
        Call Console.WriteLine(name)
        Call Console.WriteLine(parser.GlycosylNameParser(name).GetJson)
        Call Console.WriteLine(New String("-"c, 32))
    End Sub
End Module
