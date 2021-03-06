﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimServices
{
    public class ClaimsRepository
    {
        private List<Claims> _Claims = new List<Claims>();
        private Queue<Claims> ClaimsQ = new Queue<Claims>();


        public void AddContentQueue(Claims claims)
        {
            ClaimsQ.Enqueue(claims);
        }

        //public void AddContentToClaims(Claims claims)
        //{
        //    _Claims.Add(claims);
        //}

        public Claims GetByID(int id)
        {
            foreach (Claims item in ClaimsQ)
            {
                if (item.ClaimID == id)
                {
                    return item;
                }
            }
            return null;
        }

        public bool RemoveClaimFromList(int id)
        {
            Claims content = GetByID(id);

            if (content == null)
            {
                return false;
            }

            int intialCount = ClaimsQ.Count;
            ClaimsQ.Dequeue();

            if (intialCount > ClaimsQ.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateClaims(Claims updateClaim, int ID)
        {

            Claims content = GetByID(ID);
            //this works if i want to only edit the top level item in the queue
            //if(ClaimsQ.Peek().ClaimID == content.ClaimID)
            //{
            //    ClaimsQ.Dequeue();
            //    AddContentQueue(updateClaim);
            //    return true;

            //}

            if (content != null)
            {
                content.ClaimID = updateClaim.ClaimID;
                content.Description = updateClaim.Description;
                content.ClaimAmount = updateClaim.ClaimAmount;
                content.ClaimTypes = updateClaim.ClaimTypes;
                content.DateOfClaim = updateClaim.DateOfClaim;
                content.DateOfIncident = updateClaim.DateOfIncident;
                return true;
            }

            return false;
        }

        public Queue<Claims> GetClaimsQ()
        {
            return ClaimsQ;
        }

        //public List<Claims> GetClaims()
        //{
        //    return _Claims;
        //}

        public Claims GetNextClaim()
        {
            if (ClaimsQ.Count > 0)
            {
                return ClaimsQ.Peek();
            }
            return null;
        }

    }
}
