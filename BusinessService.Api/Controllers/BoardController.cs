using BusinessService.Api.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BusinessService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BoardController : ControllerBase
    {
        private readonly ICommandHandler<CreateBoardCommand, bool> _createhandler;
        private readonly ICommandHandler<UpdateBoardCommand, bool> _updatehandler;
        private readonly IQueryHandler<GetAllBoardQuery, IEnumerable<BoardDTO>> _queryhandler;

        public BoardController(ICommandHandler<CreateBoardCommand, bool> createhandler, ICommandHandler<UpdateBoardCommand, bool> updatehandler, IQueryHandler<GetAllBoardQuery, IEnumerable<BoardDTO>> queryhandler)
        {
            _createhandler = createhandler;
            _updatehandler = updatehandler;
            _queryhandler = queryhandler;
        }

        // GET
        [HttpPost]
        public JsonResult Post([FromQuery]CreateBoardCommand command)
        {
            return new JsonResult(_createhandler.Handle(command));
        }
        [HttpPut]
        public JsonResult Put([FromQuery]UpdateBoardCommand command)
        {
            return new JsonResult(_updatehandler.Handle(command));
        }

        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(_queryhandler.Handle(new GetAllBoardQuery()));
        }
    }
}