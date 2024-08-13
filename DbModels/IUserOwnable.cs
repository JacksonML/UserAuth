namespace AsyncCoder.UserAuth.DbModels {
    public interface IUserOwnable<T> where T : IUser {
        public long OwnedByUserId {get;set;}
        // public virtual T OwnedByUser {get;set;}
    }
}