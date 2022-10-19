using JiraClone.Domain.Contract.IssuesViewModel;
using JiraClone.Domain.Contract.UserViewModel;
using JiraClone.Domain.Entities;
using JiraClone.EntityFrameworkCore;
using JiraClone.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraClone.Services.Services
{
    public class IssueService : IIssuesService
    {
        private JiraCloneDbContext _jiraCloneDbContext;

        public IssueService(JiraCloneDbContext jiraDbContext)
        {
            _jiraCloneDbContext = jiraDbContext;
        }

        public async Task<List<IssuesViewModel>> AllIssues()
        {
            try
            {
                var issues = await _jiraCloneDbContext.Issues.Select(x => new IssuesViewModel
                {
                    Assignee = new UserViewModel
                    {
                        FirstName = x.Assignee.FirstName,
                        LastName = x.Assignee.LastName,
                        Id = x.Assignee.Id
                    },
                    Reporter = new UserViewModel
                    {
                        FirstName = x.reporter.FirstName,
                        LastName = x.reporter.LastName,
                        Id = x.reporter.Id
                    },
                    Status = x.Status,
                    Summary = x.Summary,
                    Description = x.Description,
                    Type = x.Summary,
                    CreatedOn = x.CreatedOn.ToLongDateString(),
                    UpdatedOn = x.UpdatedOn.ToLongDateString(),
                }).ToListAsync();

                if (issues == null)
                {
                    throw new Exception("no issues found");
                }

                return issues;

            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<IssuesViewModel> GetIssueById(int id)
        {
            try
            {
                var issue = await _jiraCloneDbContext.Issues.Where(issue => issue.Id == id).Select(x => new IssuesViewModel
                {
                    Assignee = new UserViewModel
                    {
                        FirstName = x.Assignee.FirstName,
                        LastName = x.Assignee.LastName,
                        Id = x.Assignee.Id
                    },
                    Reporter = new UserViewModel
                    {
                        FirstName = x.reporter.FirstName,
                        LastName = x.reporter.LastName,
                        Id = x.reporter.Id
                    },
                    Status = x.Status,
                    Summary = x.Summary,
                    Description = x.Description,
                    Type = x.Summary,
                    CreatedOn = x.CreatedOn.ToLongDateString(),
                    UpdatedOn = x.UpdatedOn.ToLongDateString(),
                }).FirstOrDefaultAsync();

                if (issue == null)
                {
                    throw new Exception("no issue found");
                }

                return issue;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IssuesViewModel> CreateIssue(CreateIssueViewModel issueViewModel)
        {
            try
            {
                var issue = new issue
                {
                    Type = issueViewModel.Summary,
                    Status = issueViewModel.Status,
                    Priority = issueViewModel.Priority,
                    Summary = issueViewModel.Summary,
                    Description = issueViewModel.Description,
                    reporter = _jiraCloneDbContext.Users.Where(x => x.Id == issueViewModel.UserId).FirstOrDefault(),
                    Assignee = _jiraCloneDbContext.Users.Where(x => x.Id == issueViewModel.Assignee.Id).FirstOrDefault(),
                    CreatedOn = DateTime.Now,
                };
                await _jiraCloneDbContext.Issues.AddAsync(issue);
                await _jiraCloneDbContext.SaveChangesAsync();
                return new IssuesViewModel
                {
                    Message = $"You've created 'TEAM - {issue.Id}' issue",
                    IssueId = issue.Id
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IssuesViewModel> UpdateIssue(UpdateIssueViewModel updateIssueViewModel)
        {
            try
            {
                var Issue = await _jiraCloneDbContext.Issues.FindAsync(updateIssueViewModel.UserId);
                var reporter = await _jiraCloneDbContext.Users.FindAsync(updateIssueViewModel.Reporter.Id);

                if (updateIssueViewModel == null || updateIssueViewModel.UserId < 1)
                    throw new Exception("Enter a valid IssueId");
                

                if (reporter.Id == Issue.reporter.Id)
                {
                    try
                    {
                        Issue.Summary = string.IsNullOrEmpty(updateIssueViewModel.Summary) ? Issue.Summary : updateIssueViewModel.Summary;
                        Issue.Status = string.IsNullOrEmpty(updateIssueViewModel.Status) ? Issue.Status : updateIssueViewModel.Status;
                        Issue.Priority = string.IsNullOrEmpty(updateIssueViewModel.Priority) ? Issue.Priority : updateIssueViewModel.Summary;
                        Issue.Summary = string.IsNullOrEmpty(updateIssueViewModel.Summary) ? Issue.Summary : updateIssueViewModel.Summary;
                        Issue.Description = updateIssueViewModel.Description;
                        Issue.Assignee = await _jiraCloneDbContext.Users.FindAsync(updateIssueViewModel.Assignee.Id);
                        _jiraCloneDbContext.Entry(Issue).State = EntityState.Modified;
                        await _jiraCloneDbContext.SaveChangesAsync();

                        return new IssuesViewModel
                        {
                            IssueId = Issue.Id,
                            Summary = Issue.Summary,
                            Description = Issue.Description,
                            Type = Issue.Type,
                            Status = Issue.Status,
                            Priority = Issue.Priority,
                            Assignee = new UserViewModel
                            {
                                Id = Issue.Assignee.Id,
                                FirstName = Issue.Assignee.FirstName,
                                LastName = Issue.Assignee.LastName
                            }
                        };
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
                throw new Exception("You cannot edit this issue you're not the reporter");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
