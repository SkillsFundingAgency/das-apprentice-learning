function DrawMap() {
    
    var map = game.game.data.chosenMap;

    for (var x = 0; x < mapW; x++) {
        for (var y = 0; y < mapH; y++) {
            switch (map[y][x]) {
                case 0:
                    ctx.fillStyle = "#81c97d"
                    break;
                default:
                    ctx.fillStyle = "#999999"
            }
            ctx.fillRect(x * tileW, y * tileH, tileW, tileH)
        }
    }
}