﻿using FluentValidation;
using System;
using Weapsy.Domain.Model.Languages.Commands;
using Weapsy.Domain.Model.Languages.Rules;
using Weapsy.Domain.Model.Sites.Rules;

namespace Weapsy.Domain.Model.Languages.Validators
{
    public class LanguageDetailsValidator<T> : AbstractValidator<T> where T : LanguageDetails
    {
        private readonly ILanguageRules _languageRules;
        private readonly ISiteRules _siteRules;

        public LanguageDetailsValidator(ILanguageRules languageRules, ISiteRules siteRules)
        {
            _languageRules = languageRules;
            _siteRules = siteRules;

            RuleFor(c => c.SiteId)
                .NotEmpty().WithMessage("Site id is required.")
                .Must(BeAnExistingSite).WithMessage("Site does not exist.");

            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Language name is required.")
                .Length(2, 100).WithMessage("Language name length must be between 2 and 100 characters.")
                .Must(HaveValidName).WithMessage("Language name is not valid. Enter only letters, numbers, underscores and hyphens.")
                .Must(HaveUniqueName).WithMessage("A language with the same name already exists.");

            RuleFor(c => c.CultureName)
                .NotEmpty().WithMessage("Culture name is required.")
                .Length(2, 100).WithMessage("Culture name length must be between 2 and 100 characters.")
                .Must(HaveValidCultureName).WithMessage("Culture name is not valid. Enter only letters and 1 hyphen.")
                .Must(HaveUniqueCultureName).WithMessage("A language with the same culture name already exists.");

            RuleFor(c => c.Url)
                .NotEmpty().WithMessage("Language url is required.")
                .Length(2, 100).WithMessage("Language url length must be between 2 and 100 characters.")
                .Must(HaveValidLanguageUrl).WithMessage("Language url is not valid. Enter only letters and 1 hyphen.")
                .Must(HaveUniqueLanguageUrl).WithMessage("A language with the same url already exists.");
        }

        private bool BeAnExistingSite(Guid siteId)
        {
            return _siteRules.DoesSiteExist(siteId);
        }

        private bool HaveValidName(string name)
        {
            return _languageRules.IsLanguageNameValid(name);
        }

        private bool HaveUniqueName(LanguageDetails cmd, string name)
        {
            return _languageRules.IsLanguageNameUnique(cmd.SiteId, name, cmd.Id);
        }

        private bool HaveValidCultureName(string cultureName)
        {
            return _languageRules.IsCultureNameValid(cultureName);
        }

        private bool HaveUniqueCultureName(LanguageDetails cmd, string cultureName)
        {
            return _languageRules.IsCultureNameUnique(cmd.SiteId, cultureName, cmd.Id);
        }

        private bool HaveValidLanguageUrl(string url)
        {
            return _languageRules.IsLanguageUrlValid(url);
        }

        private bool HaveUniqueLanguageUrl(LanguageDetails cmd, string url)
        {
            return _languageRules.IsLanguageUrlUnique(cmd.SiteId, url, cmd.Id);
        }
    }
}
