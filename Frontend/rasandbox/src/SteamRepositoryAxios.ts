import { Game } from "./Game";
import Games from "./response.json";
import { AxiosResponse } from "axios";

export interface SteamRepositoryAxios {
  getGame(): Promise<Game>;
}

export function loadGames() {
  return Promise.resolve(Games);
}
