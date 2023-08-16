using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulseemCMS.Domain.Common.Helpers.RegexValidators;
public class RegexValidatorHelper
{
    // Cellphone can start with 05 (len of 10 – local number) or with 9725 (len of 12 – International number) – it means that 972526292959=0526292959
    public const string PHONE_NUMBER_REG_VALIDATOR = "/(9725|05)[0-9]{8,8}/";

    public const string NAME_REG_VALIDATOR = "/[A-Za-z]{1,100}/";
}



