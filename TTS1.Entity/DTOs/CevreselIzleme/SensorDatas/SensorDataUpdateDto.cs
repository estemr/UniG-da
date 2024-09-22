﻿using TTS.Entity.DTOs.CevreselIzleme.Sensors;

namespace TTS.Entity.DTOs.CevreselIzleme.SensorDatas
{
    public class SensorDataUpdateDto
    {
        public Guid Id { get; set; }
        public Guid SensorId { get; set; }

        public string Value { get; set; }
        public string Unit { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;

        public IList<SensorDto> Sensors { get; set; }

    }
}
