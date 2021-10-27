namespace GestionRecette.Tools
{
    public static class Mappers
    {
        public static BusinessLogicLayer.Models.Users ToBLL(this TokenTools.User u)
        {
            if (u == null) { return null; }
            return new BusinessLogicLayer.Models.Users
            {
                Id = u.Id,
                Speudo = u.Speudo,
                Mdp = u.Mdp,
                Roles = u.Roles,
                Id_role = u.Id_role,
                Token = u.Token,
            };
        }

        public static TokenTools.User ToToken(this BusinessLogicLayer.Models.Users u)
        {
            if (u == null) { return null; }
            return new TokenTools.User
            {
                Id = u.Id,
                Speudo = u.Speudo,
                Mdp = u.Mdp,
                Roles = u.Roles,
                Id_role = u.Id_role,
                Token = u.Token,
            };
        }
    }
}
