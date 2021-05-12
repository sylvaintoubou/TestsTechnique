Imports Question1.BusinessEntities

Public Interface ITraitementBC
    Sub Traiter(fichier As IFichier, fichiersPilotesPourCeFichier As IEnumerable(Of FichierPilote), nomRepertoireSource As String)
End Interface
