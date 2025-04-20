// See https://aka.ms/new-console-template for more information
namespace Program
{
    public class recurse{
        public static void Main(string[] args)
        {

        }

        public static void backtrackMethod()
        {
            /*
             * let's just go straight to the nongreedy approach, and stick with the original plan
             * of a "sliding scale" system. I think I also want to have some kind of tree representation of this.
             * Afterwards, we can try the min/max approach but I think this'll be a good starting point.
             *

               /**

                * RECURSIVE method: Generates an optimal playlist using a backtracking approach to maximize the

                * total duration while staying within the maximum allowed duration.

                *

                * CITE: https://www.geeksforgeeks.org/introduction-to-backtracking-2/

                * https://www.geeksforgeeks.org/what-is-the-difference-between-backtracking-and-recursion/?ref=lbp

                * https://medium.com/@shakthits01/optimizing-problem-solving-with-backtracking-techniques-fdc8ec61c4c5

                * (All sources where used to help us figure out how implement the optimalPlaylist method, which

                * implements backtracking)

                *

                * @param songs       the list of available songs

                * @param playlist    the current playlist being generated

                * @param maxDuration the maximum allowed duration for the playlist

                * @return the optimal playlist with the maximum possible duration based on the backtracking

                * approach

                * /

               public static Playlist optimalPlaylist(ArrayList<Song> songs, Playlist playlist,

                   int maxDuration) {

                 /*

                 A good way to look at this method is as covering both cases. Starting from the empty set, how do

                 we recurse through each subset until we get to the complete set? (Alternatively, how do we

                 recurse from smallest to largest subsets through a powerset?) To consider all subsets, an

                 certain element "song" is either added or not added. Using the .canAddSong method, we cut

                 down on a number of said permutations to find out the closest playlist duration permutation

                 possible to maxDuration

                  * /



                 // Base Case 1: No more songs to consider, return current best.

                 if (songs.isEmpty()) {

                   return playlist;

                 }



                 // Base Case 2: Perfect duration, break recursion

                 if (playlist.getTotalDuration() == maxDuration) {

                   return playlist;

                 }



                 Song currentSong = songs.get(0);



                 // Case 1: exclude the current song

                 ArrayList<Song> remainingSongs = new ArrayList<>(songs);

                 remainingSongs.remove(0);

                 // recursively call optimalPlaylist without the current song

                 Playlist playlistWithoutCurrent = optimalPlaylist(remainingSongs, playlist, maxDuration);



                 // Case 2: include the current song (if it fits) -> increases efficiency

                 Playlist playlistWithCurrent = playlist;

                 if (playlist.canAddSong(currentSong, maxDuration)) {

                   playlistWithCurrent = playlist.addSong(currentSong);

                   // recursively call optimalPlaylist with the current song

                   playlistWithCurrent = optimalPlaylist(remainingSongs, playlistWithCurrent, maxDuration);

                 }



                 // A glorified recursive math.max function, to check if the playlist with current song or the

                 // playlist without current song is closer to maxDuration -- returns the closer one.

                 if (playlistWithCurrent.getTotalDuration() > playlistWithoutCurrent.getTotalDuration()) {

                   return playlistWithCurrent;

                 } else {

                   return playlistWithoutCurrent;

                 }

               }


             */

        }
    }
}