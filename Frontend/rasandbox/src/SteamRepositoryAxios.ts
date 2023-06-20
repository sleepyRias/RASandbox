import { AxiosRepository } from "./AxiosRepository";
import Games from "./response.json";
import { SteamRepository } from "@/SteamRepository";

export class SteamRepositoryAxios
  extends AxiosRepository
  implements SteamRepository
{
  public loadGames() {
    return Promise.resolve(Games.response.games);
  }
}
