namespace GameZone.Controllers
{
    public class GamesController : Controller
    {

        private readonly ICategoryService _categoryService;
        private readonly IDeviceService _deviceService;
        private readonly IGameService _gameService;

        public GamesController(ICategoryService categoryService, IDeviceService deviceService, IGameService gameService)
        {

            _categoryService = categoryService;
            this._deviceService = deviceService;
            this._gameService = gameService;
        }



        public IActionResult Index()
        {
            var games = _gameService.GetAllGames();
            return View(games);
        }




        public IActionResult Details(int id)
        {
            var game = _gameService.GetGameById(id);
            if (game == null) return NotFound();
            return View(game);
        }


        [HttpGet]  //show form
        public IActionResult Create()
        {

            CreateGameFormViewModel viewModel = new CreateGameFormViewModel()
            {
                Categories = _categoryService.GetCategories().ToList(),


                Devices = _deviceService.GetDevices().ToList(),
            };
            return View(viewModel);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]   //protection of code
        public async Task<IActionResult> Create(CreateGameFormViewModel VM)
        {

            if (!ModelState.IsValid)
            {

                VM.Categories = _categoryService.GetCategories().ToList();
                VM.Devices = _deviceService.GetDevices().ToList();
                return View(VM);
            }

            //save game to database
            //save cover to server
            await _gameService.CreateAsync(VM);
            return RedirectToAction(nameof(Index));


        }




        [HttpGet]
        public IActionResult Edit(int id)
        {
            var game = _gameService.GetGameById(id);
            if (game == null) return NotFound();
            EditGameFormViewModel viewModel = new EditGameFormViewModel()
            {
                Id = id,
                Name = game.Name,
                Description = game.Description,
                CategoryId = game.CategoryId,
                SelectedDevices = game.Devices.Select(d => d.DeviceId).ToList(),
                Categories = _categoryService.GetCategories().ToList(),


                Devices = _deviceService.GetDevices().ToList(),
                CurrentCover = game.Cover,
            };
            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]   //protection of code
        public async Task<IActionResult> Edit(EditGameFormViewModel VM)
        {

            if (!ModelState.IsValid)
            {

                VM.Categories = _categoryService.GetCategories().ToList();
                VM.Devices = _deviceService.GetDevices().ToList();
                return View(VM);
            }


            var game = await _gameService.EditAsync(VM);
            if (game == null) return BadRequest();
            return RedirectToAction(nameof(Index));


        }


        [HttpDelete]

        public IActionResult Delete(int id)
        {


            var isDeleted = _gameService.Delete(id);

            return isDeleted ? Ok() : BadRequest();

        }

    }

}

