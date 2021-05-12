

Public Class TraitementBC
    Implements ITraitementBC

    Public Property PrefixeNomFichierNonPilote As Object
    Public Property _configuration As Object
    Public Property IdentifiantTraitement As Object

    Public Sub Traiter(fichier As IFichier, fichiersPilotesPourCeFichier As IEnumerable(Of BusinessEntities.FichierPilote), nomRepertoireSource As String) Implements ITraitementBC.Traiter
        Dim CD As Codes.CodeRetour

        Dim message As String

        Dim arretTraitement As Boolean



        If fichiersPilotesPourCeFichier.Count = 0 Then

            message = fichier.NomComplet + ". Le fichier sera copié dans le répertoire " + _configuration.RepertoireFichierInconnu

            AjouterFichierExecution(fichier.NomComplet)

        End If



        If fichiersPilotesPourCeFichier.Count > 0 Then
            For Each fp In fichiersPilotesPourCeFichier

                If fp.idTraitement.Equals(IdentifiantTraitement) Then

                    AjouterFichierExecution(fichier.NomComplet)

                Else

                    AjouterFichierOrphelin(fichier.NomComplet, fp.NomPrefixFichier, fp.idTraitement)

                End If

            Next

        End If



        If message <> "" Then

            AjouterMessage(PrefixeNomFichierNonPilote, message)

        End If



        Dim repertoiresDestination = New List(Of String)

        If fichiersPilotesPourCeFichier.Count = 0 Then

            repertoiresDestination.Add(_configuration.RepertoireFichierInconnu)

        Else

            repertoiresDestination.AddRange(fichiersPilotesPourCeFichier.Where(Function(x) Not String.IsNullOrEmpty(x.NomRepertoireDestination)).Select(Function(x) String.Concat(x.NomRepertoireDestination) + "\").Distinct)

        End If



        For Each repertoireDestination In repertoiresDestination

            Dim nomCompletDestination = repertoireDestination + fichier.Nom

            CD = fichier.TryCopier(nomCompletDestination)



            If CD.Equals(Codes.CodeRetour.DossierInexistant) Then

                Dim repertoireFichierInconnu = _configuration.RepertoireFichierInconnu

                AjouterMessage(CD, "Erreur lors de la copie du fichier : " + fichier.NomComplet + ". Nom du repertoire destination : " + repertoireDestination + ". Le fichier sera copié dans le répertoire " + repertoireFichierInconnu)

                CD = fichier.TryCopier(repertoireFichierInconnu + fichier.Nom)



                If Not CD.Equals(Codes.CodeRetour.Succes) Then

                    AjouterMessage(CD, "Erreur lors de la copie du fichier : " + fichier.NomComplet + ". Nom du repertoire destination : " + repertoireFichierInconnu)

                    arretTraitement = True

                    Exit For

                End If

            ElseIf Not CD.Equals(Codes.CodeRetour.Succes) Then

                AjouterMessage(CD, "Erreur lors de la copie du fichier : " + fichier.NomComplet + ". Nom du repertoire destination : " + repertoireDestination)

                arretTraitement = True

                Exit For

            End If

        Next



        If arretTraitement Then

            Throw fichier.ExceptionCourante

        End If



        CD = fichier.TryDetruire()

        If Not CD.Equals(Codes.CodeRetour.Succes) Then

            AjouterMessage(CD, "Erreur lors de la suppression du fichier : " + fichier.NomComplet + ". Nom du repertoire source : " + nomRepertoireSource)

            arretTraitement = True

        End If



        If arretTraitement Then

            Throw fichier.ExceptionCourante

        End If



    End Sub

    Private Sub AjouterFichierOrphelin(nomComplet As String, nomPrefixFichier As Object, idTraitement As Object)
        Throw New NotImplementedException()
    End Sub

    Private Sub AjouterMessage(prefixeNomFichierNonPilote As Object, message As String)
        Throw New NotImplementedException()
    End Sub

    Private Sub AjouterFichierExecution(nomComplet As String)
        Throw New NotImplementedException()
    End Sub
End Class
