import { AxiosRepository } from "./AxiosRepository";
import { Game } from "../interfaces/Game";
import { games } from "../../src/response";
import { SteamRepository } from "../repos/SteamRepository";

export class SteamRepositoryAxios
  extends AxiosRepository
  implements SteamRepository
{
  private basePath = "https://localhost:7091/api";
  public loadGames() {
    return games;
  }
  public getGames(amount: number) {
    return this.sendGet<Game[]>(`${this.basePath}/GameController/Games`, {
      params: { amount: amount },
    });
  }
}
