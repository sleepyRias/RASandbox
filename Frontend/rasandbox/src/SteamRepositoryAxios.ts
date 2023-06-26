import { AxiosRepository } from "./AxiosRepository";
import { Game } from "./Game";
import { games } from "./response";
import { SteamRepository } from "@/SteamRepository";

export class SteamRepositoryAxios
  extends AxiosRepository
  implements SteamRepository
{
  private basePath = "/api";
  public loadGames() {
    return games;
    // localhost:xxxx/api/games
  }
  public getGames() {
    return this.sendGet<Game[]>(`${this.basePath}/games`);
  }
}
