/// <summary>
/// This delegate is similar to an EventHandler:
///   The first parameter is the sender, 
///   The second parameter is the arguments / info to pass
/// </summary>

using Handler = System.Action<System.Object, System.Object>;
namespace Queens.Systems.Events
{
    /// <summary>
    /// The SenderTable maps from an object (sender of a notification), 
    /// to a List of Handler methods
    ///    * Note - When no sender is specified for the SenderTable, 
    ///     the NotificationCenter itself is used as the sender key
    /// </summary>
    public static class NotificationExtensions
    {
        public static void PostNotification(this object obj, string notificationName)
        {
            NotificationCenter.instance.PostNotification(notificationName, obj);
        }

        public static void PostNotification(this object obj, string notificationName, object e)
        {
            NotificationCenter.instance.PostNotification(notificationName, obj, e);
        }

        public static void AddObserver(this object obj, Handler handler, string notificationName)
        {
            NotificationCenter.instance.AddObserver(handler, notificationName);
        }

        public static void AddObserver(this object obj, Handler handler, string notificationName, object sender)
        {
            NotificationCenter.instance.AddObserver(handler, notificationName, sender);
        }

        public static void RemoveObserver(this object obj, Handler handler, string notificationName)
        {
            NotificationCenter.instance.RemoveObserver(handler, notificationName);
        }

        public static void RemoveObserver(this object obj, Handler handler, string notificationName, System.Object sender)
        {
            NotificationCenter.instance.RemoveObserver(handler, notificationName, sender);
        }

    }
}
