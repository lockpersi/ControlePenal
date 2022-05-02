using AutoMapper;
using ControlePenal.Context;
using ControlePenal.Entity.Models;
using ControlePenal.Extensions;
using ControlePenal.Models;
using Microsoft.EntityFrameworkCore;

namespace ControlePenal.Application
{
    public class CriminalCodeApp
    {
        private ApiContext _context;

        public CriminalCodeApp(ApiContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Função responsavel por criar e salvar o Codigo Penal na base de dados
        /// </summary>
        /// <param name="criminalCode"></param>
        /// <returns></returns>
        public async Task<ResponseModel> CreateCriminalCodeAsync(CriminalCodeModel criminalCode)
        {
            try
            {
                var statusId = await _context.Statuses.Where(x => x.IdStatus == criminalCode.StatusId).FirstOrDefaultAsync();

                if (statusId != null)
                {
                    CriminalCodeContext cc = new()
                    {
                        Name = criminalCode.Name,
                        Description = criminalCode.Description,
                        Penalty = criminalCode.Penalty,
                        PrisonTime = criminalCode.PrisonTime,
                        StatusId = criminalCode.StatusId,
                        CreateDate = criminalCode.CreateDate,
                        UpdateDate = null,
                        CreateUserId = criminalCode.CreateUserId,
                        UpdateUserId = null
                    };

                    var result = await _context.Criminalcodes.AddAsync(cc);
                    _context.SaveChanges();

                    return new ResponseModel { Status = ResponseModel.StatusEnum.Sucess, Message = "Criminal Code criado com sucesso" };

                }
                else
                {
                    return new ResponseModel { Status = ResponseModel.StatusEnum.Error, Message = "StatusID informando inexistente" };
                }

            }
            catch (Exception ex)
            {
                return new ResponseModel { Status = ResponseModel.StatusEnum.Error, Message = ex.Message };
            }
        }

        /// <summary>
        /// Funcão responsavel por Deletar o Codigo penal da base de dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponseModel> DeleteCriminalCodeAsync(string id)
        {
            try
            {
                var criminalCode = await _context.Criminalcodes.FindAsync(id);

                if (criminalCode == null)
                    return new ResponseModel { Status = ResponseModel.StatusEnum.NotFound, Message = "Nada encontrado" };

                _context.Criminalcodes.Remove(criminalCode);
                await _context.SaveChangesAsync();

                return new ResponseModel { Status = ResponseModel.StatusEnum.Sucess, Message = "Criminal Code deletado com sucesso" };

            }
            catch (Exception ex)
            {
                return new ResponseModel { Status = ResponseModel.StatusEnum.Error, Message = ex.Message };
            }
        }

        /// <summary>
        /// Função responsavel por filtrar os campos da base de dados.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="by"></param>
        /// <param name="orderBy"></param>
        /// <param name="way"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public async Task<CriminalResponseModel> GetCriminalCodeAsync(string filter,string by, string orderBy, string way, int page)
        {
            try
            {
                IQueryable<CriminalCodeContext> criminalCodeContext = _context.Criminalcodes;
                List<CriminalCodeContext> listCodes = new List<CriminalCodeContext>();

                criminalCodeContext = criminalCodeContext.WhereEquals(by, filter);

                if (way == "asc")
                    criminalCodeContext = criminalCodeContext.OrderBy(orderBy);
                else
                    criminalCodeContext = criminalCodeContext.OrderByDescending(orderBy);

                if (page != 0)
                    listCodes = await criminalCodeContext.Skip((page - 1) * 10).Take(10).ToListAsync();
                else
                    listCodes = await criminalCodeContext.Skip(0).Take(10).ToListAsync();

                return new CriminalResponseModel { Data = listCodes, Message = "Pesquisa realizada com sucesso", Status = ResponseModel.StatusEnum.Sucess };
            }
            catch (Exception ex)
            {

                return new CriminalResponseModel { Data = null, Message = ex.Message, Status = ResponseModel.StatusEnum.Error };

            }

        }

        /// <summary>
        /// Função responsavel por pesquisar um Codigo penal especifico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CriminalResponseModel> GetAsync(int id)
        {
            try
            {
                List<CriminalCodeContext> listCodes = new List<CriminalCodeContext>();

                listCodes = await _context.Criminalcodes.Where(t => t.IdCriminalCode == id).ToListAsync();

                return new CriminalResponseModel { Data = listCodes, Message = "Pesquisa realizada com sucesso", Status = ResponseModel.StatusEnum.Sucess };

            }
            catch (Exception ex)
            {
                return new CriminalResponseModel { Data = null, Message = ex.Message, Status = ResponseModel.StatusEnum.Error };
            }
        }

        /// <summary>
        /// Função responsavel por editar um codigo penal especifico
        /// </summary>
        /// <param name="id"></param>
        /// <param name="criminalCodeModel"></param>
        /// <returns></returns>
        public async Task<ResponseModel> EditCriminalCodeAsync(int id, CriminalCodeModel criminalCodeModel)
        {
            try
            {
                var criminalCode = await _context.Criminalcodes.Where(t => t.IdCriminalCode == id).FirstOrDefaultAsync();

                if (criminalCode == null)
                    return new ResponseModel { Status = ResponseModel.StatusEnum.NotFound, Message = "Nada encontrado" };

                criminalCode.Name = criminalCodeModel.Name;
                criminalCode.Description = criminalCodeModel.Description;
                criminalCode.Penalty = criminalCodeModel.Penalty;
                criminalCode.PrisonTime = criminalCodeModel.PrisonTime;
                criminalCode.StatusId = criminalCodeModel.StatusId;
                criminalCode.UpdateDate = criminalCodeModel.UpdateDate;
                criminalCode.UpdateUserId = criminalCodeModel.UpdateUserId;

                _context.SaveChanges();

                return new ResponseModel { Status = ResponseModel.StatusEnum.Sucess, Message = "Criminal Code alterado com sucesso" };

            }
            catch (Exception ex)
            {
                return new ResponseModel { Status = ResponseModel.StatusEnum.Error, Message = ex.Message };
            }
        }



    }
}
