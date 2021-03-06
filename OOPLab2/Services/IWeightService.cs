﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab2.Services
{
    interface IWeightService: IBusinessService
    {
        float AvgWeight();

        float AvgWeightByAnimalType(Type type);
    }
}
