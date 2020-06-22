       public async Task<IEnumerable<AdmAccessGroup>> GetUnassignedAccessGrpByAccessGrpID(string accessGrpID)
        {
            var uniqueAccessGrpIDs =
               (from dbo in appDbContext.AccessGroupFunctions
                where dbo.AccessGroupID != ""
                select dbo.AccessGroupID).Distinct();

            var listAccessGrps =
               (from dbo in appDbContext.AdmAccessGroups
                where !uniqueAccessGrpIDs.Contains(dbo.AccessGroupID)
                select dbo);

            return listAccessGrps;
        }
