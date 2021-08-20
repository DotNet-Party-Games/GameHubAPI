using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HubDL;
using HubEntities.Database;

namespace HubBL {
    public class LeaderboardManager {
        private readonly IDatabase<Leaderboard> _leaderboardDB;
        private readonly IDatabase<TeamLeaderboard> _teamLeaderboardDB;
        private readonly IList<string> _includes;
        public LeaderboardManager(IDatabase<Leaderboard> leaderboardDB, IDatabase<TeamLeaderboard> teamLeaderboardDB) {
            _leaderboardDB = leaderboardDB;
            _teamLeaderboardDB = teamLeaderboardDB;
            _includes = new List<string> {
                "Scores"
            };
        }

        public async Task<Leaderboard> GetLeaderboard(string gameName) {
            if (gameName == null) throw new ArgumentException("Missing parameter gameName");

            return await _leaderboardDB.FindSingle(new() {
                Includes = _includes,
                Conditions = new List<Func<Leaderboard, bool>> {
                    lb => lb.Id == gameName
                }
            });
        }

        public async Task<bool> SubmitScore(string gameName, UserScore score) {
            if (gameName == null) throw new ArgumentException("Missing parameter gameName");
            if (score == null) throw new ArgumentException("Missing parameter score");

            Leaderboard targetLeaderboard = await _leaderboardDB.FindSingle(new() {
                Includes = _includes,
                Conditions = new List<Func<Leaderboard, bool>> {
                    lb => lb.Id == gameName
                }
            });

            targetLeaderboard.Scores.Add(score);

            return await _leaderboardDB.Save();
        }

        public async Task<TeamLeaderboard> GetTeamLeaderboard(string gameName) {
            if (gameName == null) throw new ArgumentException("Missing parameter gameName");

            return await _teamLeaderboardDB.FindSingle(new() {
                Includes = _includes,
                Conditions = new List<Func<TeamLeaderboard, bool>> {
                    lb => lb.Id == gameName
                }
            });
        }

        public async Task<bool> SubmitTeamScore(string teamName, TeamScore score) {
            if (teamName == null) throw new ArgumentException("Missing parameter teamName");
            if (score == null) throw new ArgumentException("Missing parameter score");

            TeamLeaderboard targetLeaderboard = await _teamLeaderboardDB.FindSingle(new() {
                Includes = _includes,
                Conditions = new List<Func<TeamLeaderboard, bool>> {
                    lb => lb.Id == teamName
                }
            });

            targetLeaderboard.Scores.Add(score);

            return await _teamLeaderboardDB.Save();
        }
    }
}