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
  }
  public getGames(amount: number) {
    return this.sendGet<Game[]>(`${this.basePath}/GameController/Games`, {
      params: amount,
    });
  }
}
