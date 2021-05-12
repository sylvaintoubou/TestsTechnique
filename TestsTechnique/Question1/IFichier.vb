Imports Question1.Codes

Public Interface IFichier
    ReadOnly Property NomComplet As String
    Property Nom As String
    ReadOnly Property ExceptionCourante As Exception
    Function TryCopier(nomCompletDestination As String) As CodeRetour
    Function TryDetruire() As CodeRetour
End Interface
