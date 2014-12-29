
namespace Fiszki
{
    class Score
    {
        private int Result = 10;
        private int Possible = 110;

        
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
