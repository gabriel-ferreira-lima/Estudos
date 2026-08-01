using JwtStore.Core.Contexts.AccountContext.Entities;
using JwtStore.Core.Contexts.AccountContext.UseCases.Authenticate.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JwtStore.Core.Contexts.AccountContext.UseCases.Authenticate {
    public class Handler : IRequestHandler<Request, Response> {

        private readonly IRepository _repository;

        public Handler(IRepository repository) {
            _repository = repository;
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken) {
            #region 01 - valida a requisição
            try {
                var res = Specification.Ensure(request);
                if(!res.IsValid) {
                    return new Response("Requisição invalida", 400, res.Notifications);
                }
            }
            catch (Exception e) {
                return new Response("Não foi possivel validar sua requisição", 500);
            }
            #endregion

            #region 02 - recupera o perfil
            User? user;
            try {
                user = await _repository.GetUserByEmailAsync(request.Email, cancellationToken);
                if (user == null) {
                    return new Response("Perfil não Encontrado", 404);
                }
            }
            catch (Exception e) {
                return new Response("Não foi possivel recuperar o seu perfil", 500);
            }
            #endregion

            #region 03 - verificar se a senha é valida
            if (!user.Password.Challenge(request.Password)) {
                return new Response("Usuario ou senha inválido", 400);
            }

            #endregion

            #region 04 - checa se a conta esta verificada
            try {
                if (!user.Email.Verification.IsActive) {
                    return new Response("Conta inativa", 400);
                }
            }
            catch (Exception e) {
                return new Response("Não foi possivel verificar seu perfil", 500);
            }
            #endregion

            #region 05 - retorna os dados
            try {
                var data = new ResponseData {
                    Id = user.Id.ToString(),
                    Name = user.Name,
                    Email = user.Email,
                    Roles = user.Roles.Select(x => x.Name).ToArray()
                };

                return new Response(string.Empty, data, 200);
            }
            catch (Exception e) {
                return new Response("Não foi possivel obter os dados do perfil", 500);
            }
            #endregion
        }
    }
}
