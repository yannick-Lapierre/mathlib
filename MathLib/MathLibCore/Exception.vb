Public Class Exception

  Inherits System.Exception

  ''' -----------------------------------------------------------------------------
  ''' <summary>
  ''' Constructeur
  ''' </summary>
  ''' <remarks>
  ''' </remarks>
  ''' <history>
  ''' 	[lap_y]	06/09/2005	Created
  ''' </history>
  ''' -----------------------------------------------------------------------------
  Public Sub New()

  End Sub

  ''' -----------------------------------------------------------------------------
  ''' <summary>
  ''' crée une exception predefini
  ''' </summary>
  ''' <param name="Exception_ID">ID de l'exception prédéfini à creer</param>
  ''' <remarks>
  ''' </remarks>
  ''' <code>
  ''' Throw New BLM.Tools.BLMException(2000)
  ''' </code>
  ''' <history>
  ''' 	[lap_y]	06/09/2005	Created
  ''' </history>
  ''' -----------------------------------------------------------------------------
  Public Sub New(ByVal Exception_ID As Long)
    'MyBase.New( "Error : " & Exception_ID & " : " & ID2Desc(Exception_ID))
    MyBase.New("Error : " & Exception_ID & " : " & vbCrLf & ID2Desc(Exception_ID))
    _ID = Exception_ID
    _Message = MyBase.Message
  End Sub

  ''' -----------------------------------------------------------------------------
  ''' <summary>
  '''	Crée une nouvelle exeption
  ''' </summary>
  ''' <param name="Exception_ID">ID à affecter a l'exception</param>
  ''' <param name="Desc">Message descrptif de l'exception</param>
  ''' <remarks>
  ''' </remarks>
  ''' <code>
  ''' Throw New BLM.Tools.BLMException(2000,"Message")
  ''' </code>
  ''' <history>
  ''' 	[lap_y]	06/09/2005	Created
  ''' </history>
  ''' -----------------------------------------------------------------------------
  Public Sub New(ByVal Exception_ID As Long, ByVal Desc As String)
    MyBase.New("Error : " & Exception_ID & " : " & ID2Desc(Exception_ID) & vbCrLf & " [" & Desc & "]")
    _ID = Exception_ID
    _Message = MyBase.Message
  End Sub

  ''' -----------------------------------------------------------------------------
  ''' <summary>
  '''		Identifiant de de l'exception
  ''' </summary>
  ''' <value>ID de l'exception</value>
  ''' <remarks>
  '''		<list type="table">    
  '''			<listheader>
  '''				<term>ID du bug</term>
  '''				<description>Description</description>
  '''			</listheader>
  '''			<item>
  '''				<term>1</term>
  '''				<description>Unable counting because the 3 points is lined up</description>
  '''			</item>
  '''			<item>
  '''				<term>2</term>
  '''				<description>Unable to add a node to the graph, because a node carrying the same name already exist</description>
  '''			</item>
  '''			<item>
  '''				<term>3</term>
  '''				<description>Unable to add a node to the graph, because then node name is 'Nothing'</description>
  '''			</item>
  '''			<item>
  '''				<term>4</term>
  '''				<description>Unable to access node, because node is not found</description>
  '''			</item>
  '''			<item>
  '''				<term>5</term>
  '''				<description>Impossible to eliminate the node because it does not exist</description>
  '''			</item>
  '''			<item>
  '''				<term>6</term>
  '''				<description>Unable to access Edge, because Edge is not found</description>
  '''			</item>
  '''			<item>
  '''				<term>7</term>
  '''				<description>Unable to access Edge, because node is 'Nothing'</description>
  '''			</item>
  '''			<item>
  '''				<term>8</term>
  '''				<description>Unable to access node, because node is 'Nothing'</description>
  '''			</item>
  '''     <item>
  '''				<term>9</term>
  '''				<description>This not a valide Hexadecimal value</description>
  '''			</item>
  '''			<item>
  '''				<term>10</term>
  '''				<description>points 'Start_Point' and ' Alignement_Point' are identical</description>
  '''			</item>
  '''			<item>
  '''				<term>11</term>
  '''				<description>Polygon Must have at least 3 Points</description>
  '''			</item>
  '''			<item>
  '''				<term>12</term>
  '''				<description>Value should be numerical type</description>
  '''			</item>
  '''   </list>
  ''' </remarks>
  ''' -----------------------------------------------------------------------------
  Public ReadOnly Property ID() As Long
    Get
      Return _ID
    End Get
  End Property

  ''' -----------------------------------------------------------------------------
  ''' <summary>
  ''' Retourne le descriptif de l'exeption
  ''' </summary>
  ''' <value></value>
  ''' <remarks>
  ''' </remarks>
  ''' <history>
  ''' 	[lap_y]	14/09/2005	Created
  ''' </history>
  ''' -----------------------------------------------------------------------------
  Public Overrides ReadOnly Property Message() As String
    Get

      Return _Message

    End Get
  End Property

  Private _ID As Long
  Private _Message As String

  ''' -----------------------------------------------------------------------------
  ''' <summary>
  ''' Genere le message correspondant a l'ID de l'exception
  ''' </summary>
  ''' <param name="ID">ID de l'exeption</param>
  ''' <returns>descriptif de l'ecxeption</returns>
  ''' <remarks>
  ''' </remarks>
  ''' <history>
  ''' 	[lap_y]	14/09/2005	Created
  ''' </history>
  ''' -----------------------------------------------------------------------------
  Private Shared Function ID2Desc(ByVal ID As Long) As String

    Select Case ID

      '-- Math ------------------------------------------------  
      Case -2 : Return "This function is not yet ready"
      Case -1 : Return "Undefinited error"
      Case 0 : Return "The array of points is empty or last index is lower than 2 (index 0 is not used)"
      Case 1 : Return "Unable counting because the 3 points is lined up"
      Case 2 : Return "Unable to add a node to the graph, because a node carrying the same name or ID already exist"
      Case 3 : Return "Unable to add a node to the graph, because then node name is 'Nothing'"
      Case 4 : Return "Unable to access node, because node is not found"
      Case 5 : Return "Impossible to eliminate the node because it does not exist"
      Case 6 : Return "Unable to access Edge, because Edge is not found"
      Case 7 : Return "Unable to access Edge, because node is 'Nothing'"
      Case 8 : Return "Unable to access node, because node is 'Nothing'"
      Case 9 : Return "This not a valide Hexadecimal value"
      Case 10 : Return "points 'Start_Point' & ' Alignement_Point' are identical"
      Case 11 : Return "Polygon Must have at least 3 Points"
      Case 12 : Return "Value should be numerical type"
      Case 13 : Return "Data is not a correct hexadecimal format"

        '-- Matrix -----------------------------------------------------
      Case 200 : Return "Matrix Should Have same Size"
      Case 201 : Return "The rows's size of 1st matrix should be egual at Col's size of 2nd matrix"
      Case 202 : Return "Matrix should have same rows size"
      Case 203 : Return "Matrix should have same Cols size"
      Case 204 : Return "Bad row size"
      Case 205 : Return "Bad Col size"
      Case 206 : Return "Matrix should be a squared matrix"

        '-- Points -----------------------------------------------------
      Case 300 : Return "To initialise a Point type with a matrix data, Matrix should be [2,1] or [3,1] size"

        '-- Graph ------------------------------------------------------
      Case 402 : Return "Unable to add a node to the graph, because a node carrying the same name already exist"
      Case 403 : Return "Unable to add a node to the graph, because then node name is 'Nothing'"
      Case 404 : Return "Unable to access node, because node is not found"
      Case 405 : Return "Impossible to eliminate the node because it does not exist"
      Case 406 : Return "Unable to access Edge, because Edge is not found"
      Case 407 : Return "Unable to access Edge, because node is 'Nothing'"
      Case 408 : Return "Unable to access node, because node is 'Nothing'"
      Case 409 : Return "Unable to add Edge, because Edge already exist"

        '-- Lines -----------------------------------------------------
      Case 500 : Return "Mixed Point. Points of line shoud not be have same coordinates"

      Case Else : Return ""

    End Select

  End Function

End Class
