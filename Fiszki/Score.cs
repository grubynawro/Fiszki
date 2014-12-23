
namespace Fiszki
{
    class Score
    {
        private int Result = 0;
        private int Possible = 0;

        
        public void SetResult(int result)
        {
            this.Result = result;
        }
        public void SetPossible(int possible)
        {
            this.Possible = possible;
        }
        public int GetResult()
        {
            return this.Result;
        }
        public int GetPossible()
        {
            return this.Possible;
        }
    }
}
