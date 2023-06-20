import Games from "./response.json";
import { SteamRepository } from "@/SteamRepository";

export class SteamRepositoryAxios implements SteamRepository {
  public loadGames() {
    return Promise.resolve(Games);
  }
}
