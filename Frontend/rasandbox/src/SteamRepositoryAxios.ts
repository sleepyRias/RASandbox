import { AxiosRepository } from "./AxiosRepository";
import { games } from "./response";
import { SteamRepository } from "@/SteamRepository";

export class SteamRepositoryAxios
  extends AxiosRepository
  implements SteamRepository
{
  public loadGames() {
    console.log(games);
    return Promise.resolve(games);
  }
}
