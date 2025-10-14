namespace Bitrate
{
    /// <summary>
    /// Calculates the bitrate (in bits per second) for Tx and Rx based on NIC readings taken at a specified frequency.
    /// </summary>
    public class BitrateCalculator
    {
        private readonly double timeIntervalInSec;
        const double SECOND = 1.0;

        public BitrateCalculator(double frequency)
        {
            timeIntervalInSec = SECOND / frequency;
        }

        /// <summary>
        /// Calculate the Tx bitrate in bits per second (bps) between two NIC readings.
        /// </summary>
        /// <param name="nic1">NIC reading 1</param>
        /// <param name="nic2">NIC reading 2</param>
        /// <returns>Bitrate</returns>
        public double CalculateTxBitrate(NIC nic1, NIC nic2)
        {
            if (string.IsNullOrEmpty(nic1.Tx) || string.IsNullOrEmpty(nic2.Tx))
            {
                throw new ApplicationException("Tx value is missing from input");
            }

            double tx1 = double.Parse(nic1.Tx) * 8; // Convert bytes to bits
            double tx2 = double.Parse(nic2.Tx) * 8; // Convert bytes to bits
            double delta = tx2 - tx1;

            if (delta < 0)
            {
                throw new ApplicationException("Tx value decreased between readings, possible data issue.");
            }

            double bitrate = delta / timeIntervalInSec; // bits per second
            return bitrate;
        }

        /// <summary>
        /// Calculate the Rx bitrate in bits per second (bps) between two NIC readings.
        /// </summary>
        /// <param name="nic1">NIC reading 1</param>
        /// <param name="nic2">NIC reading 2</param>
        /// <returns>Bitrate</returns>
        public double CalculateRxBitrate(NIC nic1, NIC nic2)
        {
            if (string.IsNullOrEmpty(nic1.Rx) || string.IsNullOrEmpty(nic2.Rx))
            {
                throw new ApplicationException("Rx value is missing from input");
            }

            double rx1 = double.Parse(nic1.Rx) * 8; // Convert bytes to bits
            double rx2 = double.Parse(nic2.Rx) * 8; // Convert bytes to bits

            double delta = rx2 - rx1;

            if (delta < 0)
            {
                throw new ApplicationException("Tx value decreased between readings,  possible data issue.");
            }

            double bitrate = delta / timeIntervalInSec; // bits per second
            return bitrate;
        }
    }
}
