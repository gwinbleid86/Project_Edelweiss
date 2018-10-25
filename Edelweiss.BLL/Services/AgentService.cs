using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Edelweiss.BLL.DTO;
using Edelweiss.BLL.Infrastructure;
using Edelweiss.BLL.Interfaces;
using Edelweiss.DAL.Entities;
using Edelweiss.DAL.Interfaces;
using Microsoft.AspNetCore.Hosting;
using X.PagedList;


namespace Edelweiss.BLL.Services
{
    public class AgentService : IAgentService
    {
        IUnitOfWork Database { get; set; }
        private IHostingEnvironment environment;
        private FileUploadService fileUploadService;
        private const int pageSize = 5;
        private int pageNumber { get; set; }

        
        public AgentService(IUnitOfWork uow,
            IHostingEnvironment environment,
            FileUploadService fileUploadService)
        {
            Database = uow;
            this.environment = environment;
            this.fileUploadService = fileUploadService;
        }

        public IPagedList<AgentDTO> GetAll(int page)
        {
            var agent = Database.Agents.GetAll();
            return Mapper.Map<IEnumerable<Agent>, List<AgentDTO>>(agent).ToPagedList(page, pageSize);
        }

        public IEnumerable<AgentDTO> GetAll()
        {
            var agent = Database.Agents.GetAll();
            return Mapper.Map<IEnumerable<Agent>, List<AgentDTO>>(agent);
        }

        public AgentDTO Get(int id)
        {
            Agent agent = Database.Agents.Get(id);
            return Mapper.Map<AgentDTO>(agent);
        }

        public Agent GetAgent(int id)
        {
            Agent agent = Database.Agents.Get(id);
            return Mapper.Map<Agent>(agent);
        }

        public AgentDTO SingleOrDefault(Func<Agent, bool> predicate)
        {
            return Mapper.Map<AgentDTO>(Database.Agents.SingleOrDefault(predicate));
        }

        //public IEnumerable<AgentDTO> Find(Func<Agent, bool> predicate)
        //{
        //    throw new NotImplementedException();
        //    //return Mapper.Map<IEnumerable<Agent>, List<AgentDTO>>(Database.Agents.Find(predicate).ToList());
        //}

        public IQueryable<AgentDTO> Find(Expression<Func<Agent, bool>> predicate)
        {
            return Mapper.Map<IQueryable<AgentDTO>>(Database.Agents.Find(predicate));
        }

        public void Create(AgentDTO agent)
        {
            string path = Path.Combine(
                environment.WebRootPath,
                $"images\\{agent.Name}\\");
            var map = Mapper.Map<Agent>(agent);
            if (agent.ParentAgentId == null)
            {
                if (agent.ImageLogo != null)
                {
                    var imageLogo = $"/images/{agent.Name}/{agent.ImageLogo.FileName}";
                    fileUploadService.Upload(path, agent.ImageLogo.FileName, agent.ImageLogo);
                    map.ImageLogo = imageLogo;
                }
                if (agent.ImagePromo != null)
                {
                    var imagePromo = $"/images/{agent.Name}/{agent.ImagePromo.FileName}";
                    fileUploadService.Upload(path, agent.ImagePromo.FileName, agent.ImagePromo);
                    map.ImagePromo = imagePromo;
                }
            }
            else
            {
                CheckParentAgentExistance(agent.ParentAgentId, out string logo, out string promo, out string text);
                map.ImageLogo = logo;
                map.ImagePromo = promo;
                map.TextPromo = text;
            }
            

            //if (agent.ImagePromo != null)
            //{
            //    var imagePromo = $"/images/{agent.Name}/{agent.ImagePromo.FileName}";
            //    fileUploadService.Upload(path, agent.ImagePromo.FileName, agent.ImagePromo);
            //    map.ImagePromo = imagePromo;
            //}
            //string path = Path.Combine(
            //    environment.WebRootPath,
            //    $"images\\{agent.Name}\\");

            //fileUploadService.Upload(path, agent.ImageLogo.FileName, agent.ImageLogo);
            Database.Agents.Create(map);
            Database.Save();
        }

        public void Update(AgentDTO agent)
        {
            string path = Path.Combine(
                environment.WebRootPath,
                $"images\\{agent.Name}\\");
            var map = Mapper.Map<Agent>(agent);
            if (agent.ParentAgentId == null)
            {
                if (agent.ImageLogo != null)
                {
                    var imageLogo = $"/images/{agent.Name}/{agent.ImageLogo.FileName}";
                    fileUploadService.Upload(path, agent.ImageLogo.FileName, agent.ImageLogo);
                    map.ImageLogo = imageLogo;
                }
                if (agent.ImagePromo != null)
                {
                    var imagePromo = $"/images/{agent.Name}/{agent.ImagePromo.FileName}";
                    fileUploadService.Upload(path, agent.ImagePromo.FileName, agent.ImagePromo);
                    map.ImagePromo = imagePromo;
                }
            }
            else
            {
                CheckParentAgentExistance(agent.ParentAgentId, out string logo, out string promo, out string text);
                map.ImageLogo = logo;
                map.ImagePromo = promo;
                map.TextPromo = text;
            }

            Database.Agents.Update(map);
            Database.Save();
        }

        public void Delete(int id)
        {
            Database.Agents.Delete(id);
            Database.Save();
        }
        public List<User> FindAgentUsersForBlock(int id)
        {
            IQueryable<Agent> childrenOfagentForBlock =Database.Agents.Find(a=>a.ParentAgentId==id);
            
            var users = Database.Users.Find(u=>u.AgentId==id).ToList();
            foreach (Agent agent in childrenOfagentForBlock)
            {
                users.AddRange(agent.User);
            }
            return  users;
        }

        public void AgentBlock(int id)
        {
            Agent agentForBlock = Database.Agents.Get(id);
            agentForBlock.IsBlocked = true;
            Database.Agents.Update(agentForBlock);
            Database.Save();
        }

        public void AgentUnBlock(int id)
        {
            Agent agentForBlock = Database.Agents.Get(id);
            agentForBlock.IsBlocked = false;
            Database.Agents.Update(agentForBlock);
            Database.Save();
        }

        public int GetAgentByUserId(string userId)
        {
            User user = Database.Users.GetByUserId(userId);
            return GetAgent(user.AgentId).CountryId;
        }
        //public void AgentForBlock(int id)
        //{
        //    Agent agentForBlock = Database.Agents.Get(id);
        //    agentForBlock.IsBlocked = true;
        //    //_agentService.Update(agentForBlock);
        //    Database.Agents.Update(agentForBlock);
        //    Database.Save();
        //}

        public void CheckParentAgentExistance(int? id, out string logo, out string promo, out string text)
        {
            Agent parentAgent = Database.Agents.SingleOrDefaultAsNoTracking(a => a.Id == id);
            logo = parentAgent.ImageLogo;
            promo = parentAgent.ImagePromo;
            text = parentAgent.TextPromo;
        }
    }
}
