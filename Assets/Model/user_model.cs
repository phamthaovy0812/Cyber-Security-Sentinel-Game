using Firebase.Firestore;

[FirestoreData]

public struct User{
    [FirestoreProperty]
    public string email {get; set;}
    [FirestoreProperty]
    public string id {get; set;}
        [FirestoreProperty]
    public string password {get; set;}
    [FirestoreProperty]
    public string username {get; set;}
    [FirestoreProperty]
    public string experience {get; set;}
    [FirestoreProperty]
    public string id_level {get; set;}

    


}