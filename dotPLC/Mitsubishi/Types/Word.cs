﻿using dotPLC.Initial;
using System;
using System.Text.RegularExpressions;

namespace dotPLC.Mitsubishi.Types
{
    /// <summary>
    /// Implements a <see cref="Bit"/> [16-bit data] device.
    /// </summary>
    public class Word
    {
        /// <summary>
        /// label
        /// </summary>
        private string _label;
        /// <summary>
        /// index
        /// </summary>
        private int _index;
        /// <summary>
        /// device
        /// </summary>
        private string _device;

        /// <summary>
        /// Initializes a new instance of <see cref="Word"></see> [16-bit data] device.
        /// </summary>
        public Word()
        {
        }
        /// <summary>
        /// Initializes a new instance of <see cref="Word"></see> [16-bit data] device which determines label name.
        /// </summary>
        /// <param name="label">Label name. (EX: D0, Y2, M10, etc.)</param>
        public Word(string label)
        {
            label = sWhitespace.Replace(label, "").ToUpper();
            string device;
            int num;
            if (!Ethernet.SettingDevice(label, out device, out num))
                throw new ArgumentOutOfRangeException("The specified device does not belong to the memory of the PLC");
            _label = label;
            _device = device;
            _index = num;
        }
        /// <summary>
        /// Initializes a new instance of <see cref="Word"></see> [16-bit data] device which determines label name and [signed 16-bit] value.
        /// </summary>
        /// <param name="label">Label name. (EX: D0, Y2, M10, etc.)</param>
        /// <param name="value">Signed 16-bit data.</param>
        public Word(string label, short value)
        {
            label = sWhitespace.Replace(label, "").ToUpper();
            string device;
            int num;
            if (!Ethernet.SettingDevice(label, out device, out num))
                throw new ArgumentOutOfRangeException("The specified device does not belong to the memory of the PLC");
            _label = label;
            _device = device;
            _index = num;
            Value = value;
        }
        /// <summary>
        /// Initializes a new instance of <see cref="Word"></see> device which determines label name and [unsigned 16-bit] value.
        /// </summary>
        /// <param name="label">Label name. (EX: D0, Y2, M10, etc.)</param>
        /// <param name="value">Unsigned 16-bit data.</param>
        public Word(string label, ushort value)
        {
            label = sWhitespace.Replace(label, "").ToUpper();
            string device;
            int num;
            if (!Ethernet.SettingDevice(label, out device, out num))
                throw new ArgumentOutOfRangeException("The specified device does not belong to the memory of the PLC");
            _label = label;
            _device = device;
            _index = num;
            ValueU = value;
        }
        /// <summary>
        /// Creates device and index
        /// </summary>
        /// <param name="device">device</param>
        /// <param name="index">index</param>
        protected internal void Create(string device, int index)
        {
            if (!Ethernet.SettingLabel(device, index, out _label))
                throw new ArgumentOutOfRangeException("The specified device does not belong to the memory of the PLC");
            _device = device;
            _index = index;
        }
        /// <summary>
        /// Gets or sets label name of device. (EX: D0, Y2, M10, etc.)
        /// </summary>
        public string Label
        {
            get => _label;
            set
            {
                string label_temp = sWhitespace.Replace(value, "").ToUpper();
                string device;
                int num;
                if (!Ethernet.SettingDevice(label_temp, out device, out num))
                    throw new ArgumentOutOfRangeException("The specified device does not belong to the memory of the PLC");
                _device = device;
                _index = num;
                _label = label_temp;
            }
        }
        /// <summary>
        /// index
        /// </summary>
        protected internal int Index
        {
            get => _index;
            set
            {
                if (!Ethernet.SettingLabel(_device, value, out _label))
                    throw new ArgumentOutOfRangeException("The specified device does not belong to the memory of the PLC");
                _index = value;
            }
        }
        /// <summary>
        /// device
        /// </summary>
        protected internal string Device
        {
            get => _device;
            set
            {
                if (!Ethernet.SettingLabel(value, _index, out _label))
                    throw new ArgumentOutOfRangeException("The specified device does not belong to the memory of the PLC");
                _device = value;
            }
        }
        /// <summary>
        /// value short
        /// </summary>
        private short _value;
        /// <summary>
        /// Clear space.
        /// </summary>
        static readonly Regex sWhitespace = new Regex(@"\s+");
        /// <summary>
        /// value ushort
        /// </summary>
        private ushort _valueU;
        /// <summary>
        /// Gets or sets [signed 16-bit] value of device.
        /// </summary>
        public short Value
        {
            get => _value;
            set
            {
                _value = value;
                _valueU = (ushort)value;
            }
        }
        /// <summary>
        /// Gets or sets [unsigned 16-bit] value of device.
        /// </summary>
        public ushort ValueU
        {
            get => _valueU;
            set
            {
                _valueU = value;
                _value = (short)value;
            }
        }
    }
}
