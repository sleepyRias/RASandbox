import { Game } from "./Game";
import Games from "./response.json";

export interface SteamRepositoryAxios {
  getGame(): Promise<Game>;
}

export function loadGames() {
  return Promise.resolve(Games);
}
