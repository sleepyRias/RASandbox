import { Game } from "./Game";

export interface SteamRepositoryAxios {
  getGame(): Promise<Game>;
  loadGames(): any;
}
