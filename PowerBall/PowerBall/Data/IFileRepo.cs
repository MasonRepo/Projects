using System.Collections.Generic;

namespace PowerBall.Data
{
    public interface IPickRepository
    {
        //THIS HAS YET TO BE IMPLEMENTED I'M NOT 100% SURE HOW TO GO ABOUT IT BECAUSE MY FILE REPO IS DIFFERENT AND I DON'T KNOW WHAT THE REQUIREMENT IS WITHOUT CHANGING
        //MY ENTIRE FILE REPO CODE

        void WriteFile(Powerball pick); // The return value is a Pick with a valid identifier.

        Powerball FindById(int identifier); // Returns the Pick with the given identifier 
                                              // or null if not found.
        IEnumerable<Powerball> FindBestMatches(Powerball draw); // A powerball draw is supplied as a Pick. 
                                                      // Returns the Picks that best matches the draw.d
    }
}