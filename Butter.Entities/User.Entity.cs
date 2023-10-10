namespace Butter.Entities
{
    public class UserEntity

    {
        public int UserId { get; set; }
        public string NickName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Town { get; set; }

        //! Amis
        public ICollection<FriendsEntity> MyFriends { get; set; }

        //!Amis de 
        public ICollection <FriendsEntity> Friends { get; set; }


    }
}