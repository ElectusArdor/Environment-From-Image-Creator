using UnityEngine;

public static class ShowMessage
{
    public static void WrongFileExtension()
    {
        CreateMessage("Данный формат файла не поддерживается");
    }

    private static void CreateMessage(string messageText)
    {
        Debug.Log(messageText);
    }
}
