namespace GraduationTracker
{
    //Interface is of Generic type allowing any repository Class to implement it
    public interface IRepository<T> where T : class
    {
        dynamic FetchRecordByID(int id);
    }
}