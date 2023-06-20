/* eslint-disable @typescript-eslint/no-explicit-any */
import { Game } from "./Game";
export interface SteamRepository {
  loadGames(): Game[];
}
