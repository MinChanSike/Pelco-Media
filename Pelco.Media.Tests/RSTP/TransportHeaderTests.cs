﻿using Pelco.Media.RTSP;
using Xunit;

namespace Pelco.Media.Tests.RSTP
{
    public class TransportHeaderTests
    {
        [Fact]
        public void TestParseVxSpoofedTransport()
        {
            var transport = TransportHeader.Parse("RTP/AVP/TCP;unicast;interleaved=0-1");

            Assert.Equal(TransportType.RtspInterleaved, transport.Type);
            Assert.Equal(0, transport.InterleavedChannels.RtpPort);
            Assert.Equal(1, transport.InterleavedChannels.RtcpPort);
        }

        [Fact]
        public void TestParseUnicastTransport()
        {
            var transport = TransportHeader.Parse("RTP/AVP;unicast;client_port=8000-8001");

            Assert.Equal(TransportType.UdpUnicast, transport.Type);
            Assert.Equal(8000, transport.ClientPorts.RtpPort);
            Assert.Equal(8001, transport.ClientPorts.RtcpPort);
        }
    }
}
