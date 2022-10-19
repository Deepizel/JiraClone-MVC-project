using JiraClone.Domain.Contract.IssuesViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JiraClone.Services.IServices
{
    interface IIssuesService
    {
        List<IssuesViewModel> AllIssues();
        Task<IssuesViewModel> GetIssueById(int id);
        Task<IssuesViewModel> CreateIssue(CreateIssueViewModel viewModel);
        Task<string> UpdateIssue(UpdateIssueViewModel updateIssueViewModel);



    }
}
