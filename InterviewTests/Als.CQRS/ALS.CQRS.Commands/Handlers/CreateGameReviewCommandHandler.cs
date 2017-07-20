using ALS.CQRS.Domain;
using JetBrains.Annotations;
using SimpleCqrs.Commanding;
using SimpleCqrs.Domain;

namespace ALS.CQRS.Commands.Handlers
{
    [UsedImplicitly]
    public class CreateGameReviewCommandHandler
        : CommandHandler <CreateGameReviewCommand>
    {
        public CreateGameReviewCommandHandler(
            [NotNull] IDomainRepository repository)
        {
            m_Repository = repository;
        }

        private readonly IDomainRepository m_Repository;

        public override void Handle(
            [NotNull] CreateGameReviewCommand command)
        {
            Return(ValidateCommand(command));

            var review = new GameReview(command.Title,
                                        command.Description,
                                        command.Rating);

            m_Repository.Save(review);
        }

        private GameReviewHandlerStatus ValidateCommand(
            [NotNull] CreateGameReviewCommand command)
        {
            return command.Rating < 0
                       ? GameReviewHandlerStatus.Failed
                       : GameReviewHandlerStatus.Successful;
        }
    }
}