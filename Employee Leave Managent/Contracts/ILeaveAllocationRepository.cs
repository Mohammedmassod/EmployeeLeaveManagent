using AutoMapper;
using Employee_Leave_Managent.Data;
using Employee_Leave_Managent.Models;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Leave_Managent.Contracts
{

    public interface ILeaveAllocationRepository : IRepositoryBase<LeaveAllocation>
    {
        //#Interface Segregation Principle 1
        bool CheckAllocation(int leavetypeid, string employeeid);
        ICollection<LeaveAllocation> GetLeaveAllocationsByEmployee(string employeeid);
        LeaveAllocation GetLeaveAllocationsByEmployeeAndType(string employeeid, int leavetypeid);
    }
   
}
